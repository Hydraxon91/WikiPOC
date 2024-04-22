import React, { useEffect, useState, useRef } from 'react';
import { Link, useParams} from 'react-router-dom';
import '../../../Styles/style.css';
import '../../WikiPage-Article/Style/wikipagecomponent.css'
import { useStyleContext } from '../../../Components/contexts/StyleContext';

const TestWikiPageComponent = ({page, setDecodedTitle, activeTab, images}) => {
  const { styles }  = useStyleContext();
  const { title } = useParams();
  const decodedTitle = decodeURIComponent(title);
  const [pTitles, setPTitles] = useState([]);
  const [isContentsVisible, setIsContentsVisible] = useState(true);

  useEffect(() => {
    if (page) {
      const extractedTitles = extractParagraphTitles(page.content);
      setPTitles(extractedTitles);
      // console.log(extractedTitles);
    }
  }, [page]);

  useEffect(() => {
    if (setDecodedTitle) {
      setDecodedTitle(decodedTitle);
    }
  }, [decodedTitle]);

  const toggleContentsVisibility = () => {
    setIsContentsVisible(!isContentsVisible);
  };

  const extractParagraphTitles = (htmlContent) => {
    const mainRegex = /<h2>(.*?)<\/h2>/g; // Regular expression to match main paragraphs
    const subRegex = /<h3>(.*?)<\/h3>/g; // Regular expression to match subparagraphs

    let mainParagraphs = [];
    let subparagraphs = [];

    // Extract main paragraphs
    let mainMatch;
    while ((mainMatch = mainRegex.exec(htmlContent)) !== null) {
        const mainId = `main-${mainParagraphs.length + 1}`; // Generate unique ID for main paragraph
        mainParagraphs.push({ id: mainId, text: mainMatch[1] }); // Store the ID and text content of the main paragraph
    }

    // Extract subparagraphs and associate them with main paragraphs
    let subMatch;
    while ((subMatch = subRegex.exec(htmlContent)) !== null) {
        const subId = `sub-${subparagraphs.length + 1}`; // Generate unique ID for subparagraph
        let nearestMainIndex = -1;
        let nearestMainDistance = Number.MAX_SAFE_INTEGER;

        // Find the nearest main paragraph before the current subparagraph
        for (let i = 0; i < mainParagraphs.length; i++) {
            const mainIndex = htmlContent.indexOf(mainParagraphs[i].text);
            const subIndex = subMatch.index;
            const distance = subIndex - mainIndex;
            if (distance >= 0 && distance < nearestMainDistance) {
                nearestMainIndex = i;
                nearestMainDistance = distance;
            }
        }

        if (nearestMainIndex !== -1) {
            // Associate the subparagraph with the found main paragraph
            subparagraphs.push({
                id: subId, // Store the ID and text content of the subparagraph
                mainId: mainParagraphs[nearestMainIndex].id,
                text: subMatch[1]
            });
        }
    }

    return { mainParagraphs, subparagraphs };
};

  const processHTMLContent = (htmlContent) => {
    htmlContent = imageRefRegex(htmlContent);
    // Decode HTML entities
    const decodedContent = htmlContent.replace(/&lt;/g, '<').replace(/&gt;/g, '>');

    // Split the content by the delimiter '||'
    const parts = decodedContent.split(/\|\|/);

    let parCounter = 0;
    let subParCounter = 0;

    // Process each part
    const processedParts = parts.map(part => {
        // Define regular expressions
        const classRegex = /([^\/]+)\/\//;
        const imageRegex = /<a\s+href="([^"]+)"[^>]*>ImageRef<\/a>##/;
        const textRegex = /<p>(.*?)<\/p>/g;

        // console.log("Part:", part); // Log the part content
        // Match each part of the paragraph
        const classMatch = part.match(classRegex);
        const imageMatch = part.match(imageRegex);
        const textMatch = Array.from(part.matchAll(textRegex)).map(match => match[1]);

        // Check if all matches are found
        if (classMatch && imageMatch && textMatch) {
            // Extract the class name, image reference, and text content
            const className = classMatch[1].trim();
            const imageRef = imageMatch[1].trim();
            const text = textMatch.map(match => `<p>${match.trim()}</p>`).join('\n');
            // Construct the new HTML structure
            return createHTMLElement(className, imageRef, text)
        } else {
            // Replace <h2> and <h3> tags with IDs containing the counter and increment counter      
            return part.replace(/<h2>/g, () => `<h2 id="main-${++parCounter}">`).replace(/<h3>/g, () => `<h3 id="sub-${++subParCounter}">`);

        }
      });

    // Reconstruct the content with processed parts
    const reconstructedContent = processedParts.join('');

    // Render the reconstructed content as JSX
    return <div dangerouslySetInnerHTML={{ __html: reconstructedContent }} />
  };

  const imageRefRegex = (htmlContent) =>{
    const imageRefRegex = /src="([^"]+)"/g;

    // Replace image references with actual image data URLs
    const processedContent = htmlContent.replace(imageRefRegex, (match, imageRef) => {
        // Find the image in the images array
        const image = images.find(img => img.name === imageRef);
        // If image exists, replace the reference with the data URL, otherwise keep the original reference
        return image ? `src="${image.dataURL}"` : match;
    });

    return processedContent;
  }

  const createHTMLElement = (className, imageRef, text) =>{
    const image = images.find(image => image.name === imageRef);
    console.log(image);
    if (image) {
      const constructedParts = `<div class="${className}" style="background-color: rgb(60, 95, 184);">
                    <div class="articleRightInner" style="background-color: rgb(43, 78, 166);">
                        <img class="paragraphImage" src="${image.dataURL}" alt="logo"/>
                    </div>
                    <div class="wikipage-content-container">${text}</div>
                </div>`;
    return constructedParts;
    }
  };


  return (
    <>
      {page && (
        <div className={activeTab === 'wiki' ? 'wikipage-component' : 'wikipage-component wikipage-hidden'}>
          <h1>
            {page.title}
            <Link to={`/page/${page.title}/edit`}>
              <img className = "editButton" src="/img/edit.png" alt="Edit" />
            </Link>
          </h1>

          <p className="siteSub">{`${page.siteSub}`}</p>
          <p className="roleNote">{`${page.roleNote}`}</p>
          {pTitles.mainParagraphs && pTitles.mainParagraphs.length > 0 && (
            <div 
              className={`contentsPanel ${isContentsVisible ? '' : 'minimizedPanel'}`}
              style={{backgroundColor: styles.articleRightColor}} 
            >
              <div className="hidePanel" onClick={toggleContentsVisibility}>[hide]</div>
              <div className="showPanel" onClick={toggleContentsVisibility}>[show]</div>
              <div className="contentsHeader">Contents</div>
              <ul style={{ display: isContentsVisible ? 'block' : 'none' }}>
              {pTitles.mainParagraphs.map((paragraph, mainIndex) => (
                <li key={`main-${mainIndex}`}>
                    <span>{`${mainIndex + 1}`}</span>
                    <a href={`#main-${mainIndex + 1}`}>
                        {paragraph.text}
                    </a>
                    {pTitles.subparagraphs && pTitles.subparagraphs.length > 0 && (
                        <ul>
                            {pTitles.subparagraphs.filter(subParagraph => subParagraph.mainId === paragraph.id).map((subParagraph, subIndex) => (
                                <li key={`sub-${subIndex}`}>
                                    <span>{`${mainIndex + 1}.${subIndex + 1}`}</span>
                                    <a href={`#sub-${subIndex + 1}`}>
                                        {subParagraph.text}
                                    </a>
                                </li>
                            ))}
                        </ul>
                    )}
                </li>
              ))
              }
              </ul>
            </div>
          )}


          { processHTMLContent(page.content) }
          {/* {page.paragraphs.map((paragraph, index) => (
            <div key={`paragraph-${index}`} ref={(el) => (targetRefs.current[index] = el)} className={page.approved === false ? 'update-paragraph' : ''}>
              {index!==0 && <h2>{paragraph.title}</h2>}
              {paragraph.paragraphImage && paragraph.paragraphImage !== "" && (
                <div className="articleRight" style={{ backgroundColor: styles.articleRightColor }}>
                  <div className="articleRightInner" style={{ backgroundColor: styles.articleRightInnerColor }}>
                    <img className='paragraphImage' src={paragraph.paragraphImage} alt="logo" />
                  </div>
                  {renderParagraphs(paragraph.paragraphImageText)}
                  
                </div>
              )}

              {renderParagraphs(paragraph.content, Boolean(paragraph.paragraphImage))}

            </div>
          ))} */}
        </div>
      )}
    </>
  );
};

export default TestWikiPageComponent;
