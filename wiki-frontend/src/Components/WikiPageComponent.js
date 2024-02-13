import React, { useEffect, useState, useRef } from 'react';
import { Link, useParams, useLocation} from 'react-router-dom';
import '../Styles/style.css';
import { useStyleContext } from './contexts/StyleContext';

const WikiPageComponent = ({page, setDecodedTitle}) => {
  const { styles }  = useStyleContext();
  const { title } = useParams();
  const decodedTitle = decodeURIComponent(title);
  const location = useLocation();
  const targetRef = useRef(null);
  const [pTitles, setPTitles] = useState([]);
  const [isContentsVisible, setIsContentsVisible] = useState(true);

  useEffect(() => {
    if (page) {
      const paragraphTitles = page.paragraphs.map((paragraph) => paragraph.title).slice(1);
      setPTitles(paragraphTitles);
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

  const scrollToParagraph = () => {
    if (targetRef.current) {
      targetRef.current.scrollIntoView({ behavior: 'smooth' });
    }
  };

  
  const parseLinks = (text) => {
    if (text === null) {
      return text;
    }
    const linkRegex = /<Link to="(.*?)">(.*?)<\/Link>/g;
    let match;
    const elements = [];

    let lastIndex = 0;
    while ((match = linkRegex.exec(text)) !== null) {
      const plainText = text.substring(lastIndex, match.index);
      if (plainText) {
        // elements.push(<span key={`text-${lastIndex}`}>{plainText}</span>);
        elements.push(plainText);
      }

      const linkPath = match[1];
      const linkLabel = match[2];
      elements.push(
        <Link key={`link-${match.index}`} to={linkPath}>
          {linkLabel}
        </Link>
      );

      lastIndex = match.index + match[0].length;
    }

    const remainingText = text.substring(lastIndex);
    if (remainingText) {
      elements.push(<span key={`text-${lastIndex}`}>{remainingText}</span>);
    }

    return elements;
  };



  const renderParagraphs = (content, hasParagraphImage) => {
    const additionalLines = hasParagraphImage ? Math.max(9 - content.split('<p>').length, 0) : 0;
  
    return (
      <>
        <div dangerouslySetInnerHTML={{ __html: content }} />
        {Array.from({ length: additionalLines }).map((_, i) => (
          <br key={`empty-line-${i}`} />
        ))}
      </>
    );
  };
  

  return (
    <>
      {page && (
        <div style={{minWidth: "45%"}}>
          {
            location.pathname.match(/^\/user-updates\/(\d+)$/) && (
              <>
              {page.approved === false ? (
                <h1>User Submitted Update</h1>
              ) : (
                <h1>Original Page</h1>
              )}
            </>
            )
          }
          <h1>
            {page.title}
            <Link to={`/page/${page.title}/edit`}>
              <img className = "editButton" src="/img/edit.png" alt="Edit" />
            </Link>
          </h1>

          <p className="siteSub">{`${page.siteSub}`}</p>
          <p className="roleNote">{`${page.roleNote}`}</p>

          {page.paragraphs.map((paragraph, index) => (
            <div key={`paragraph-${index}`} className={page.approved === false ? 'update-paragraph' : ''}>
              {index!==0 && <h2>{paragraph.title}</h2>}
              {paragraph.paragraphImage && paragraph.paragraphImage !== "" && (
                <div className="articleRight" style={{ backgroundColor: styles.articleRightColor }}>
                  <div className="articleRightInner" style={{ backgroundColor: styles.articleRightInnerColor }}>
                    <img className='paragraphImage' src={paragraph.paragraphImage} alt="logo" />
                  </div>
                  {parseLinks(paragraph.paragraphImageText)}
                  
                </div>
              )}

              {renderParagraphs(paragraph.content, Boolean(paragraph.paragraphImage))}

              {index === 0 && pTitles.length > 0 && 
                (
                  <div className={`contentsPanel ${isContentsVisible ? '' : 'minimizedPanel'}`}>
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
          ))}
        </div>
      )}
    </>
  );
};

export default WikiPageComponent;
