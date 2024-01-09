import React from 'react';
import { useParams, Link } from 'react-router-dom';

const WikiPage = ({ pages }) => {
  const { title  } = useParams();
  const decodedTitle = decodeURIComponent(title);
  const page = pages.find((p) => p.title === decodedTitle);

  return (
    <div>
      {page && (
        <div>
          <h2>{page.title}</h2>
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
      <Link to={`/`}>
        <button >Back to Home</button>
      </Link>
      <Link to={`/edit/${page.id}`}>
        <button>Edit</button>
      </Link>
    </div>
  );
};

export default WikiPage;
