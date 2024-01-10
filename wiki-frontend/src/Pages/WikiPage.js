import React from 'react';
import { useParams, Link } from 'react-router-dom';
import '../Styles/style.css';

const WikiPage = ({ pages }) => {
  const { title  } = useParams();
  const decodedTitle = decodeURIComponent(title);
  const page = pages.find((p) => p.title === decodedTitle);

  return (
    <div>
      {page && (
        <div className="article">
          <h2>
            {page.title}
            <Link to={`/edit/${page.id}`}>
              <img className = "editButton" src="/img/edit.png" alt="Edit" />
            </Link>
          </h2>
          
          {/* <div dangerouslySetInnerHTML={{ __html: page.content }} /> */}
          {page.paragraphs.map((paragraph, index) => (
            <div key={index}>
              <h3>{paragraph.title}</h3>
              {/* <p>{paragraph.content}</p> */}
              <div dangerouslySetInnerHTML={{ __html: paragraph.content }} /> 
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default WikiPage;
