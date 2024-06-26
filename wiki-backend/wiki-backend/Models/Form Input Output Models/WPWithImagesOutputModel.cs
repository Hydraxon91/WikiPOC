﻿namespace wiki_backend.Models;

public class WPWithImagesOutputModel
{
    public WikiPage? WikiPage { get; set; }
    public UserSubmittedWikiPage? UserSubmittedWikiPage { get; set; }
    public List<ImageFormModel>? Images { get; set; }
}