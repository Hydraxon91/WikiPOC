import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';

const WikiPage = ({ pages }) => {
  const { id } = useParams();
  const page = pages.find((p) => p.id.toString() === id);
  const navigate = useNavigate();

  const handleBack = () => {
    navigate('/');
  };
  return (
    <div>
      {page && (
        <div>
          <h2>{page.title}</h2>
          <p>{page.content}</p>
        </div>
      )}
      <button onClick={handleBack}>Back to Home</button>
    </div>
  );
};

export default WikiPage;
