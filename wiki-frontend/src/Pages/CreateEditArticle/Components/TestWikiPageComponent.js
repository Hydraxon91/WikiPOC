import React, { useEffect, useState, useRef } from 'react';
import { Link, useParams} from 'react-router-dom';
import '../../../Styles/style.css';
import { useStyleContext } from '../../../Components/contexts/StyleContext';

const TestWikiPageComponent = ({page, setDecodedTitle, activeTab}) => {
  const { styles }  = useStyleContext();
  const { title } = useParams();
  const decodedTitle = decodeURIComponent(title);
  const targetRefs = useRef([]);
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

  const scrollToParagraph = (index) => {
    console.log(index);
    console.log(targetRefs.current);
    if (targetRefs.current[index]) { 
      console.log("test");
      targetRefs.current[index].scrollIntoView({ behavior: 'smooth' });
    }
  };

  const scrollToSubParagraph = (index, subIndex) => {
    console.log(index);
    console.log(subIndex);
    console.log(targetRefs.current[index]);
    if (targetRefs.current[index]) { 
      console.log("test");
      targetRefs.current[index].scrollIntoView({ behavior: 'smooth' });
    }
  };

  const extractParagraphTitles = (htmlContent) => {
    const mainRegex = /<h2>(.*?)<\/h2>/g; // Regular expression to match main paragraphs
    const subRegex = /<h3>(.*?)<\/h3>/g; // Regular expression to match subparagraphs

    let mainMatches = [];
    let subparagraphs = [];

    // Extract main paragraphs
    let mainMatch;
    while ((mainMatch = mainRegex.exec(htmlContent)) !== null) {
        mainMatches.push(mainMatch[1]); // Store the text content of the main paragraph
    }

    // Extract subparagraphs and associate them with main paragraphs
    let currentMainIndex = 0; // Keep track of the index of the current main paragraph
    let subMatch;
    while ((subMatch = subRegex.exec(htmlContent)) !== null) {
        // Find the nearest main paragraph before the current subparagraph
        while (currentMainIndex < mainMatches.length - 1 && subMatch.index > htmlContent.indexOf(mainMatches[currentMainIndex + 1])) {
            currentMainIndex++;
        }
        // Associate the subparagraph with the current main paragraph
        subparagraphs.push({
            mainParagraph: mainMatches[currentMainIndex], // Associate the subparagraph with the current main paragraph
            text: subMatch[1] // Store the text content of the subparagraph
        });
    }

    // Return an array of objects containing main paragraphs and their associated subparagraphs
    return mainMatches.map((mainParagraph, index) => {
        const relatedSubparagraphs = subparagraphs.filter(sub => sub.mainParagraph === mainParagraph).map(sub => sub.text);
        return {
            mainParagraph: mainParagraph,
            subparagraphs: relatedSubparagraphs
        };
    });
};

  const processHTMLContent = (htmlContent, targetRefs) => {
    // Decode HTML entities
    const decodedContent = htmlContent.replace(/&lt;/g, '<').replace(/&gt;/g, '>');

    // Split the content by the delimiter '||'
    const parts = decodedContent.split(/\|\|/);

    let parCounter = -1;
    let subParCounter = -1;

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
            return `<div class="${className}" style="background-color: rgb(60, 95, 184);">
                <div class="articleRightInner" style="background-color: rgb(43, 78, 166);">
                    <img class="paragraphImage" src="${imageRef}" alt="logo"/>
                </div>
                <div class="wikipage-content-container">${text}</div>
            </div>`;
        } else {
            // Replace <h2> and <h3> tags with IDs containing the counter and increment counter
            return part.replace(/<h2>/g, () => `<h2 ref={(el) => (targetRefs.current[++parCounter] = el)} id="par${parCounter}">`)
                       .replace(/<h3>/g, () => `<h3 ref={(el) => (targetRefs.current[++subParCounter] = el)} id="subpar${subParCounter}">`);

;

            return part.replace(/<h2>/g, () => `<h2 id="par${++parCounter}">`).replace(/<h3>/g, () => `<h3 id="subpar${++subParCounter}">`);

        }
      });

    // Reconstruct the content with processed parts
    const reconstructedContent = processedParts.join('');

    // Render the reconstructed content as JSX
    return <div dangerouslySetInnerHTML={{ __html: reconstructedContent }} />
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
          {pTitles.length > 0 && (
            <div 
              className={`contentsPanel ${isContentsVisible ? '' : 'minimizedPanel'}`}
              style={{backgroundColor: styles.articleRightColor}} 
            >
              <div className="hidePanel" onClick={toggleContentsVisibility}>[hide]</div>
              <div className="showPanel" onClick={toggleContentsVisibility}>[show]</div>
              <div className="contentsHeader">Contents</div>
              <ul style={{ display: isContentsVisible ? 'block' : 'none' }}>
                {pTitles.map((paragraph, mainIndex) => (
                  <li key={`main-${mainIndex}`}>
                    <span>{`${mainIndex + 1}`}</span>
                    <Link to="#" onClick={() => scrollToParagraph(mainIndex)}>
                      {paragraph.mainParagraph}
                    </Link>
                    {paragraph.subparagraphs.length > 0 && (
                      <ul>
                        {paragraph.subparagraphs.map((subParagraph, subIndex) => (
                          <li key={`sub-${subIndex}`}>
                            <span>{`${mainIndex + 1}.${subIndex + 1}`}</span>
                            <Link to="#" onClick={() => scrollToParagraph(mainIndex, subIndex)}>
                              {subParagraph}
                            </Link>
                          </li>
                        ))}
                      </ul>
                    )}
                  </li>
                ))}
              </ul>
            </div>
          )}


          { processHTMLContent(page.content, targetRefs) }
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
