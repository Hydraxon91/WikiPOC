import React, { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import '../Styles/style.css';
import { useStyleContext } from './contexts/StyleContext';
import { getWikiPageByTitle } from '../Api/wikiApi';

const WikiPageComponent = ({setCurrentWikiPage, page}) => {
  const { title  } = useParams();
  const decodedTitle = decodeURIComponent(title);
  const { styles }  = useStyleContext();

  const [pTitles, setPTitles] = useState([]);

  useEffect(() => {
    fetchPage();
  }, [decodedTitle]);


  const fetchPage = async () => {
    try {
      const data = await getWikiPageByTitle(decodedTitle);
      setCurrentWikiPage(data);
      const paragraphTitles = data.paragraphs.map((paragraph) => paragraph.title).filter((title) => title !== null);
      setPTitles(paragraphTitles);

    } catch (error) {
      console.error('Error fetching page:', error);
    }
  };

  const renderParagraphs = (content, hasParagraphImage) => {
    const lines = content.split('\n');
    const additionalLines = hasParagraphImage ? Math.max(7 - lines.length, 0) : 0;
  
    const parseLinks = (text) => {
      const linkRegex = /<Link to="(.*?)">(.*?)<\/Link>/g;
      let match;
      const elements = [];
  
      let lastIndex = 0;
      while ((match = linkRegex.exec(text)) !== null) {
        const plainText = text.substring(lastIndex, match.index);
        if (plainText) {
          elements.push(<span key={`text-${lastIndex}`}>{plainText}</span>);
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

    return (
      <>
        {lines.map((line, lineIndex) => (
          <p key={lineIndex}>{parseLinks(line)}</p>
        ))}
        {Array.from({ length: additionalLines }).map((_, i) => (
          <br key={`empty-line-${i}`} />
        ))}
      </>
    );
  };
  

  return (
    <>
      {page && (
        <>
          <h1>
            {page.title}
            <Link to={`/page/${page.title}/edit`}>
              <img className = "editButton" src="/img/edit.png" alt="Edit" />
            </Link>
          </h1>

          <p class="siteSub">{`${page.siteSub}`}</p>
          <p class="roleNote">{`${page.roleNote}`}</p>

          {page.paragraphs.map((paragraph, index) => (
            <div key={`paragraph-${index}`}>
              {!paragraph.introductionParagraph && <h2>{paragraph.title}</h2>}
              {paragraph.paragraphImage && paragraph.paragraphImage !== "" && (
                <div className="articleRight" style={{ backgroundColor: styles.articleRightColor }}>
                  <div className="articleRightInner" style={{ backgroundColor: styles.articleRightInnerColor }}>
                    <img className='paragraphImage' src={paragraph.paragraphImage} alt="logo" />
                  </div>
                  {paragraph.paragraphImageText}
                </div>
              )}

              {index === 0 && pTitles.length > 0 && 
              (<div className='contentsPanel'>
                <div class="hidePanel">[hide]</div>
                <div class="showPanel">[show]</div>
                <div class="contentsHeader">Contents</div>
                <ul style={{display: 'block'}}>
                  {pTitles.map((paragraphTitle, titleIndex) => (
                      <li key={`title-${titleIndex}`}>
                        <span>{`${titleIndex + 1}`}</span>
                        <Link to={`#${paragraphTitle}`}>{paragraphTitle}</Link>
                      </li>
                    ))}
                </ul>
              </div>)}

              {renderParagraphs(paragraph.content, Boolean(paragraph.paragraphImage))}

            </div>
          ))}
        </>
      )}
    </>
  );
};

export default WikiPageComponent;
