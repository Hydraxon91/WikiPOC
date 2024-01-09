import React from 'react';

const WikiPage = ({ page }) => {
  return (
    <div>
      <h2>{page.title}</h2>
      <p>{page.content}</p>
    </div>
  );
};

export default WikiPage;
