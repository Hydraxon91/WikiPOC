import React from 'react';
import EditPageShared from './EditPageShared';

const CreatePage = ({ onSubmit }) => {
  // State specific to creating a new page
  const [title, setTitle] = useState('');
  const [siteSub, setSiteSub] = useState('');
  const [roleNote, setRoleNote] = useState('');
  const [paragraphs, setParagraphs] = useState([]);
  const [newPage, setNewPage] = useState(true);

  return (
    <EditPageShared
      title={title}
      siteSub={siteSub}
      roleNote={roleNote}
      paragraphs={paragraphs}
      newPage={newPage}
      onSubmit={onSubmit}
      onSave={(data) => console.log('Save not implemented for CreatePage', data)}
    />
  );
};

export default CreatePage;
