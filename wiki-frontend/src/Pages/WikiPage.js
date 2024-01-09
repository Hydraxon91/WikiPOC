import React from 'react';
import { useParams } from 'react-router-dom';

const WikiPage = ({ pages }) => {
  const { id } = useParams();
  const page = pages.find((p) => p.id.toString() === id);
  return (
    <div>
      {page && (
        <div>
          <h2>{page.title}</h2>
          <p>{page.content}</p>
        </div>
      )}
    </div>
  );
};

export default WikiPage;
