using Azure;
using Microsoft.EntityFrameworkCore;
using wiki_backend.Models;
using System;

namespace wiki_backend.DatabaseServices.Repositories;

public class WikiPageRepository : IWikiPageRepository
{
    private readonly WikiDbContext _context;
    private readonly ICategoryRepository _categoryRepository;

    public WikiPageRepository(WikiDbContext context)
    {
        _context = context;
        _categoryRepository = new CategoryRepository(_context);
    }

    public async Task<List<TitleAndCategory>> GetAllTitlesAndCategoriesAsync()
    {
        var titlesAndCategories = await _context.WikiPages
            .Where(page => !(page is UserSubmittedWikiPage) || 
                           _context.UserSubmittedWikiPages.Any(userPage => page.Id == userPage.Id && userPage.Approved))
            .Select(page => new TitleAndCategory
            {
                Title = page.Title ?? "Untitled",
                Category = page.Category.CategoryName ?? "Uncategorized"
            })
            .ToListAsync();

        return titlesAndCategories;
    }

    public async Task<IEnumerable<WikiPage>> GetAllAsync()
    {
        return await _context.WikiPages
            .Include(wp => wp.Paragraphs)
            .ToListAsync();
    }

    public async Task<WPWithImagesOutputModel?> GetByIdAsync(Guid id)
    {
        var wikiPage = await _context.WikiPages
            .Include(wp => wp.Paragraphs)
            .Include(wp => wp.Comments)
                .ThenInclude(uc => uc.UserProfile)
            .Include(wp=> wp.Comments)
                .ThenInclude(uc => uc.Replies)
            .SingleOrDefaultAsync(wp => wp.Id == id);
        
        if (wikiPage!=null)
        {
            var directoryPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"),"articles", wikiPage.Id.ToString());
            Console.WriteLine(directoryPath);
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Got into the directory");
                var imageFiles = Directory.GetFiles(directoryPath);
                var images = imageFiles.Select(file =>
                {
                    var fileName = Path.GetFileName(file);
                    var imageData = File.ReadAllBytes(file);
                    var dataURL =
                        $"data:image/{Path.GetExtension(fileName).TrimStart('.')};base64,{Convert.ToBase64String(imageData)}";
                    return new ImageFormModel
                    {
                        FileName = fileName,
                        DataURL = dataURL
                    };
                }).ToList();

                return new WPWithImagesOutputModel
                {
                    WikiPage = wikiPage,
                    Images = images
                };
            }
            else
            {
                return new WPWithImagesOutputModel
                {
                    WikiPage = wikiPage,
                    Images = null
                };
            }
        }

        return null;
    }

    public async Task<WPWithImagesOutputModel?> GetByTitleAsync(string title)
    {
        var wikiPage = await _context.WikiPages
            .Where(page => !(page is UserSubmittedWikiPage) || (_context.UserSubmittedWikiPages.Any(userPage => userPage.Id == page.Id && userPage.Approved)))
            .Include(p => p.Paragraphs)
            .Include(wp => wp.Comments)
                .ThenInclude(uc => uc.UserProfile)
            .FirstOrDefaultAsync(p => p.Title == title);
        
        if (wikiPage!=null)
        {
            var directoryPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"),"articles", wikiPage.Id.ToString());
            Console.WriteLine(directoryPath);
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Got into the directory");
                var imageFiles = Directory.GetFiles(directoryPath);
                var images = imageFiles.Select(file =>
                {
                    var fileName = Path.GetFileName(file);
                    var imageData = File.ReadAllBytes(file);
                    var dataURL =
                        $"data:image/{Path.GetExtension(fileName).TrimStart('.')};base64,{Convert.ToBase64String(imageData)}";
                    return new ImageFormModel
                    {
                        FileName = fileName,
                        DataURL = dataURL
                    };
                }).ToList();

                return new WPWithImagesOutputModel
                {
                    WikiPage = wikiPage,
                    Images = images
                };
            }
            else
            {
                return new WPWithImagesOutputModel
                {
                    WikiPage = wikiPage,
                    Images = null
                };
            }
        }

        return null;
    }

    public async Task AddAsync(WikiPage wikiPage, ICollection<ImageFormModel> images)
    {
        Console.WriteLine($"AddAsync wikipage id: {wikiPage.Id}");
        if (images.Count>0)
        {
            foreach (var image in images)
            {
                var directoryPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"),"articles" ,wikiPage.Id.ToString());
                Directory.CreateDirectory(directoryPath);
                var filePath = Path.Combine(directoryPath, image.FileName);
                var imageData = Convert.FromBase64String(image.DataURL.Split(',')[1]);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileStream.WriteAsync(imageData, 0, imageData.Length);
                }
            }
        }
        
        foreach (var paragraph in wikiPage.Paragraphs)
        {
            paragraph.Id = new Guid();
            paragraph.WikiPage = wikiPage;
            paragraph.WikiPageId = wikiPage.Id;
        }
        
        // Add the article to the category
        await _categoryRepository.AddArticleToCategoryAsync(wikiPage.CategoryId.Value, wikiPage);
        
        await _context.SaveChangesAsync();
    }

    public async Task AddUserSubmittedPageAsync(UserSubmittedWikiPage wikiPage, ICollection<ImageFormModel> images)
    {
        if (images.Count>0)
        {
            foreach (var image in images)
            {
                var directoryPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"),"articles" ,wikiPage.Id.ToString());
                Directory.CreateDirectory(directoryPath);
                var filePath = Path.Combine(directoryPath, image.FileName);
                var imageData = Convert.FromBase64String(image.DataURL.Split(',')[1]);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileStream.WriteAsync(imageData, 0, imageData.Length);
                }
            }
        }
        
        foreach (var paragraph in wikiPage.Paragraphs)
        {
            paragraph.Id = new Guid();
            paragraph.WikiPage = wikiPage;
            paragraph.WikiPageId = wikiPage.Id;
        }
        _context.UserSubmittedWikiPages.Add(wikiPage);
        await _context.SaveChangesAsync();
    }
    
    public async Task AcceptUserSubmittedWikiPage(UserSubmittedWikiPage userSubmittedWikiPage)
    {
        _context.Entry(userSubmittedWikiPage).State = EntityState.Modified;
        // Add the article to the category
        await _categoryRepository.AddArticleToCategoryAsync(userSubmittedWikiPage.CategoryId.Value, userSubmittedWikiPage);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(WikiPage existingWikiPage, WikiPage updatedWikiPage, ICollection<ImageFormModel> images)
    {
        // Console.WriteLine(updatedWikiPage);
        // Console.WriteLine(existingWikiPage);
        existingWikiPage.Title = updatedWikiPage.Title;
        existingWikiPage.RoleNote = updatedWikiPage.RoleNote;
        existingWikiPage.SiteSub = updatedWikiPage.SiteSub;
        existingWikiPage.Paragraphs = updatedWikiPage.Paragraphs;
        existingWikiPage.Content = updatedWikiPage.Content;
        existingWikiPage.CategoryId = updatedWikiPage.CategoryId;
        existingWikiPage.LegacyWikiPage = updatedWikiPage.LegacyWikiPage;
        existingWikiPage.LastUpdateDate = DateTime.Now;
        
        // Remove paragraphs that are not present in the updatedWikiPage
        var paragraphsToRemove = existingWikiPage.Paragraphs
            .Where(existingParagraph => updatedWikiPage.Paragraphs.All(updatedParagraph => updatedParagraph.Id != existingParagraph.Id))
            .ToList();
        
        foreach (var paragraphToRemove in paragraphsToRemove)
        {
            _context.Paragraphs.Remove(paragraphToRemove);
            existingWikiPage.Paragraphs.Remove(paragraphToRemove);
        }

        // Create a dictionary for efficient lookup
        var existingParagraphsDict = existingWikiPage.Paragraphs.ToDictionary(p => p.Id);

        foreach (var updatedParagraph in updatedWikiPage.Paragraphs)
        {
            // Check if the updated paragraph exists
            if (existingParagraphsDict.TryGetValue(updatedParagraph.Id, out var existingParagraph))
            {
                // Update existing paragraph
                existingParagraph.Title = updatedParagraph.Title;
                existingParagraph.Content = updatedParagraph.Content;
                existingParagraph.ParagraphImage = updatedParagraph.ParagraphImage;
                existingParagraph.ParagraphImageText = updatedParagraph.ParagraphImageText;
            }
            else
            {
                // Create a new instance of Paragraph
                var newParagraph = new Paragraph
                {
                    Title = updatedParagraph.Title,
                    Content = updatedParagraph.Content,
                    ParagraphImage = updatedParagraph.ParagraphImage,
                    ParagraphImageText = updatedParagraph.ParagraphImageText,
                    WikiPageId = existingWikiPage.Id
                };

                // Add the new instance to both collections
                _context.Paragraphs.Add(newParagraph);
                existingWikiPage.Paragraphs.Add(newParagraph);
            }
        }
        
        if (images.Count>0)
        {
            foreach (var image in images)
            {
                var directoryPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"),"articles" ,existingWikiPage.Id.ToString());
                Directory.CreateDirectory(directoryPath);
                var filePath = Path.Combine(directoryPath, image.FileName);
                var imageData = Convert.FromBase64String(image.DataURL.Split(',')[1]);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileStream.WriteAsync(imageData, 0, imageData.Length);
                }
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task AcceptUserSubmittedUpdateAsync(UserSubmittedWikiPage userSubmittedWikiPage)
    {
        // Set Approved to true
        userSubmittedWikiPage.Approved = true;
        // Add the new article to the category
        await _categoryRepository.AddArticleToCategoryAsync(userSubmittedWikiPage.CategoryId.Value, userSubmittedWikiPage);

        await _context.SaveChangesAsync();
    }

    public async Task UserSubmittedUpdateAsync(UserSubmittedWikiPage updatedWikiPage, ICollection<ImageFormModel> images)
    {
        // Console.WriteLine("inside UserSubmittedUpdateAsync");
        foreach (var paragraph in updatedWikiPage.Paragraphs)
        {
            paragraph.Id = new Guid();
            paragraph.WikiPage = updatedWikiPage;
            paragraph.WikiPageId = updatedWikiPage.Id;
        }
        
        if (images.Count>0)
        {
            foreach (var image in images)
            {
                var directoryPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"),"articles", updatedWikiPage.Id.ToString());
                Directory.CreateDirectory(directoryPath);
                var filePath = Path.Combine(directoryPath, image.FileName);
                var imageData = Convert.FromBase64String(image.DataURL.Split(',')[1]);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileStream.WriteAsync(imageData, 0, imageData.Length);
                }
            }
        }
        
        _context.UserSubmittedWikiPages.Add(updatedWikiPage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var wikiPage = await _context.WikiPages
            .Include(wp => wp.Paragraphs)
            .Include(wp => wp.Comments)
            .SingleOrDefaultAsync(wp => wp.Id == id);

        if (wikiPage != null)
        {
            // Remove the associated folder
            var folderPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"), "articles", wikiPage.Id.ToString());
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
            
                    
            // Remove the old article from the category
            await _categoryRepository.RemoveArticleFromCategoryAsync(wikiPage.CategoryId.Value, wikiPage.Id);

            // Remove paragraphs and the wiki page itself
            _context.Paragraphs.RemoveRange(wikiPage.Paragraphs);
            _context.WikiPages.Remove(wikiPage);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteUserSubmittedAsync(Guid id, Guid? newId)
    {
        var wikiPage = await _context.UserSubmittedWikiPages
            .Include(wp => wp.Paragraphs)
            .Include(wp => wp.Comments)
            .SingleOrDefaultAsync(wp => wp.Id == id);

        if (wikiPage != null)
        {
            // Console.WriteLine("Removing old article paragraphs");
            _context.Paragraphs.RemoveRange(wikiPage.Paragraphs);
            // Console.WriteLine("Removing old article");
            _context.WikiPages.Remove(wikiPage);
            // Console.WriteLine("Saving context");
            await _context.SaveChangesAsync();
            // Console.WriteLine("Saved Context");
            
            if (newId != null)
            {
                // Console.WriteLine($"New id is: {newId}");
                // Rename the old folder to the new ID if new ID is not null
                var oldFolderPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"), "articles", id.ToString());
                var newFolderPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"), "articles", newId.ToString());
                // Console.WriteLine($"newfolderpath: {newFolderPath}");
                if (Directory.Exists(oldFolderPath))
                {
                    // Console.WriteLine($"folder exists: {oldFolderPath}, moving it to {newFolderPath}");
                    Directory.Move(oldFolderPath, newFolderPath);
                }
            }
            else
            {
                // Console.WriteLine($"newid is null");
                // Delete the old folder if new ID is null
                var oldFolderPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"), "articles", id.ToString());
                // Console.WriteLine($"oldfolder is: {oldFolderPath}");
                if (Directory.Exists(oldFolderPath))
                {
                    // Console.WriteLine($"Oldfolder exists, deleting it");
                    Directory.Delete(oldFolderPath, true);
                }
            }
        }
    }
    
    public async Task<IEnumerable<Tuple<string, Guid>>> GetSubmittedPageTitlesAndIdAsync()
    {
        return await _context.UserSubmittedWikiPages.Where(page => page.IsNewPage && !page.Approved).Select(page => new Tuple<string, Guid>(page.Title, page.Id)).ToListAsync();
    }
    
    public async Task<WPWithImagesOutputModel?> GetSubmittedPageByIdAsync(Guid id)
    {
        // Console.WriteLine($"inside GetSubmittedPageByIdAsync, id: {id}");
        var wikiPage = await _context.UserSubmittedWikiPages
            .Where((page => page.IsNewPage==true))
            .Include(p => p.Paragraphs)
            .Include(wp => wp.Comments)
            .ThenInclude(uc => uc.UserProfile)
            .FirstOrDefaultAsync(p => p.Id == id);
        Console.WriteLine($"wikipage: {wikiPage}");
        
        if (wikiPage!=null)
        {
            var directoryPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"),"articles", wikiPage.Id.ToString());
            Console.WriteLine(directoryPath);
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Got into the directory");
                var imageFiles = Directory.GetFiles(directoryPath);
                var images = imageFiles.Select(file =>
                {
                    var fileName = Path.GetFileName(file);
                    var imageData = File.ReadAllBytes(file);
                    var dataURL =
                        $"data:image/{Path.GetExtension(fileName).TrimStart('.')};base64,{Convert.ToBase64String(imageData)}";
                    return new ImageFormModel
                    {
                        FileName = fileName,
                        DataURL = dataURL
                    };
                }).ToList();

                return new WPWithImagesOutputModel
                {
                    UserSubmittedWikiPage = wikiPage,
                    Images = images
                };
            }
            else
            {
                return new WPWithImagesOutputModel
                {
                    UserSubmittedWikiPage = wikiPage,
                    Images = null
                };
            }
        }

        return null;
    }
    
    public async Task<IEnumerable<Tuple<string, Guid>>> GetSubmittedUpdateTitlesAndIdAsync()
    {
        return await _context.UserSubmittedWikiPages.Where(page => page.IsNewPage==false && !page.Approved).Select(page => new Tuple<string, Guid>(page.Title, page.Id)).ToListAsync();
    }
    
    public async Task<WPWithImagesOutputModel?> GetSubmittedUpdateByIdAsync(Guid id)
    {
        var wikiPage = await _context.UserSubmittedWikiPages
            .Where((page => page.IsNewPage==false))
            .Include(p => p.Paragraphs)
            .Include(wp => wp.Comments)
            .ThenInclude(uc => uc.UserProfile)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (wikiPage!=null)
        {
            var directoryPath = Path.Combine(Environment.GetEnvironmentVariable("PICTURES_PATH_CONTAINER"),"articles", wikiPage.Id.ToString());
            Console.WriteLine(directoryPath);
            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine("Got into the directory");
                var imageFiles = Directory.GetFiles(directoryPath);
                var images = imageFiles.Select(file =>
                {
                    var fileName = Path.GetFileName(file);
                    var imageData = File.ReadAllBytes(file);
                    var dataURL =
                        $"data:image/{Path.GetExtension(fileName).TrimStart('.')};base64,{Convert.ToBase64String(imageData)}";
                    return new ImageFormModel
                    {
                        FileName = fileName,
                        DataURL = dataURL
                    };
                }).ToList();

                return new WPWithImagesOutputModel
                {
                    UserSubmittedWikiPage = wikiPage,
                    Images = images
                };
            }
            else
            {
                return new WPWithImagesOutputModel
                {
                    UserSubmittedWikiPage = wikiPage,
                    Images = null
                };
            }
        }

        return null;
    }
}