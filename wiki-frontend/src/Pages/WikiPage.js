import React from 'react';
import { useParams, Link } from 'react-router-dom';

const WikiPage = ({ pages }) => {
  const { id } = useParams();
  const page = pages.find((p) => p.id.toString() === id);

  return (
    <div>
      {page && (
        <div>
          <h2>{page.title}</h2>
          <div dangerouslySetInnerHTML={{ __html: page.content }} />
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
