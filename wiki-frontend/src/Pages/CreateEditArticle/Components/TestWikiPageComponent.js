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
    //   const paragraphTitles = page.paragraphs.map((paragraph) => paragraph.title).slice(1);
    //   setPTitles(paragraphTitles);
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
    if (targetRefs.current[index]) {
      targetRefs.current[index].scrollIntoView({ behavior: 'smooth' });
    }
  };


  
  const processHTMLContent = (htmlContent) => {
    // Decode HTML entities
    const decodedContent = htmlContent.replace(/&lt;/g, '<').replace(/&gt;/g, '>');

    // Split the content by the delimiter '||'
    const parts = decodedContent.split(/\|\|/);

    // Process each part
    const processedParts = parts.map(part => {
        // Define regular expressions
        const classRegex = /([^\/]+)\/\//;
        const imageRegex = /<a\s+href="([^"]+)"[^>]*>ImageRef<\/a>##/;
        const textRegex = /<p>(.*?)<\/p>/g;

        console.log("Part:", part); // Log the part content

        // Match each part of the paragraph
        const classMatch = part.match(classRegex);
        console.log(classMatch);
        const imageMatch = part.match(imageRegex);
        console.log(imageMatch);
        const textMatch = Array.from(part.matchAll(textRegex)).map(match => match[1]);
        console.log(textMatch);

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
            // Leave other parts unchanged
            return part;
        }
      });

    // Reconstruct the content with processed parts
    const reconstructedContent = processedParts.join('');

    // Render the reconstructed content as JSX
    return <div dangerouslySetInnerHTML={{ __html: reconstructedContent }} />;
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

              {index === 0 && pTitles.length > 0 && 
                (
                  <div 
                    className={`contentsPanel ${isContentsVisible ? '' : 'minimizedPanel'}`}
                    style={{backgroundColor: styles.articleRightColor}} 
                  >
                    <div className="hidePanel"  onClick={toggleContentsVisibility}>[hide]</div>
                    <div className="showPanel"  onClick={toggleContentsVisibility}>[show]</div>
                    <div className="contentsHeader">Contents</div>
                    <ul style={{ display: isContentsVisible ? 'block' : 'none' }}>
                    {pTitles.map((paragraphTitle, titleIndex) => (
                      <li key={`title-${titleIndex}`}>
                        <span>{`${titleIndex + 1}`}</span>
                        <Link to="#" onClick={() => scrollToParagraph(titleIndex)}>
                          {paragraphTitle}
                        </Link>
                      </li>
                    ))}
                    </ul>
                  </div>
                )
              }

            </div>
          ))} */}
        </div>
      )}
    </>
  );
};

export default TestWikiPageComponent;
