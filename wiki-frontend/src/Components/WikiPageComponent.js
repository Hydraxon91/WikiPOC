import React from 'react';
import { useParams, Link } from 'react-router-dom';
import '../Styles/style.css';
import { useStyleContext } from './contexts/StyleContext';

const WikiPageComponent = ({ pages }) => {
  const { title  } = useParams();
  const decodedTitle = decodeURIComponent(title);
  const page = pages.find((p) => p.title === decodedTitle);
  const { styles }  = useStyleContext();

  const renderParagraphs = (content, hasParagraphImage) => {
    const lines = content.split('\n');
    const additionalLines = hasParagraphImage ? Math.max(7 - lines.length, 0) : 0;
  
    return (
      <>
        {lines.map((line, lineIndex) => (
          <p key={lineIndex}>{line}</p>
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
            <Link to={`/edit/${page.id}`}>
              <img className = "editButton" src="/img/edit.png" alt="Edit" />
            </Link>
          </h1>
          <p class="siteSub">{`${page.siteSub}`}</p>
          <p class="roleNote">{`${page.roleNote}`}</p>
          {page.paragraphs.map((paragraph, index) => (
            <div key={`paragraph-${index}`}>
              <h2>{paragraph.title}</h2>
              {paragraph.paragraphImage && paragraph.paragraphImage !== "" && (
                <div className="articleRight" style={{backgroundColor: styles.articleRightColor}}>
                  <div className="articleRightInner" style={{backgroundColor: styles.articleRightInnerColor}}>
                    <img className='paragraphImage' src={paragraph.paragraphImage} alt="logo"/>
                  </div>
                  This is a test div
                </div>
              )}
              {renderParagraphs(paragraph.content, Boolean(paragraph.paragraphImage))}
            </div>
          ))}
        </>
      )}
    </>
  );
};

export default WikiPageComponent;
