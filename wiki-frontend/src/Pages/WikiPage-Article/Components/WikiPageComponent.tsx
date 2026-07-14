import { useEffect, useState } from 'react';
import { Link, useParams} from 'react-router-dom';
import type { CSSProperties } from 'react';
import '../../../Styles/style.css';
import '../../WikiPage-Article/Style/wikipagecomponent.css'
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { useUserContext } from '../../../Components/contexts/UserContextProvider';
import { extractParagraphTitles, processArticleContent, buildContentFromParagraphs } from '../../../utils/articleRenderer';

const WikiPageComponent = ({page, setDecodedSlug, activeTab, images}) => {
  const { styles }  = useStyleContext();
  const { decodedTokenContext } = useUserContext();
  const { slug } = useParams();
  const decodedSlug = decodeURIComponent(slug);
  const [pTitles, setPTitles] = useState<{mainParagraphs: {id:string;text:string}[]; subparagraphs: {id:string;mainId:string;text:string}[]}>({mainParagraphs: [], subparagraphs: []});
  const [isContentsVisible, setIsContentsVisible] = useState(true);

  useEffect(() => {
    if (page?.content) {
      setPTitles(extractParagraphTitles(page.content));
    }
  }, [page]);

  useEffect(() => {
    if (setDecodedSlug) {
      setDecodedSlug(decodedSlug);
    }
  }, [decodedSlug, setDecodedSlug]);

  const toggleContentsVisibility = () => {
    setIsContentsVisible(!isContentsVisible);
  };

  const renderEditButton = () => {
    if (!decodedTokenContext) return null;
    if (!window.location.pathname.includes('/page/')) return null;
    if (window.location.pathname.includes('/edit')) return null;
    return (
      <Link to={`/page/${page.slug}/edit`}>
        <img className="editButton" src="/img/edit.png" alt="Edit" />
      </Link>
    );
  };

  const contentHtml = page?.content
    ? page.content
    : page?.paragraphs
    ? buildContentFromParagraphs(page.paragraphs)
    : '';
  const renderedContent = contentHtml
    ? processArticleContent(contentHtml, images)
    : '';

  return (
    <div className="wiki-article-content" style={{backgroundColor: styles.articleColor, '--article-right-color': styles.articleRightColor, '--article-right-inner-color': styles.articleRightInnerColor, '--footer-link-color': styles.footerListLinkTextColor, display: activeTab !== 'wiki' ? 'none' : undefined} as CSSProperties}>
      {page && (
        <div className={activeTab === 'wiki' ? 'wikipage-component' : 'wikipage-component wikipage-hidden'}>
          <h1>
            {page.title}
            {renderEditButton()}
          </h1>
          {page.siteSub && (<p className="siteSub">{`${page.siteSub}`}</p>)}
          {page.roleNote && <p className="roleNote">{`${page.roleNote}`}</p>}
          {pTitles.mainParagraphs.length > 0 && (
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
                    {pTitles.subparagraphs.length > 0 && (
                        <ul>
                            {pTitles.subparagraphs.filter(sp => sp.mainId === paragraph.id).map((subParagraph, subIndex) => (
                                <li key={`sub-${subIndex}`}>
                                    <span>{`${mainIndex + 1}.${subIndex + 1}`}</span>
                                    <a href={`#${subParagraph.id}`}>
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

          <div dangerouslySetInnerHTML={{ __html: renderedContent }} />
        </div>
      )}
    </div>
  );
};

export default WikiPageComponent;
