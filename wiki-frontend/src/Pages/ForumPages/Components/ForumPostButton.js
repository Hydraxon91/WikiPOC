import React from 'react';
import { Link } from 'react-router-dom';
import '../Styles/modularbutton.css';

const ForumPostButton = ({ buttonTitle, linkTo }) => {
    return (
        <Link to={linkTo} className="modular-button">
            {buttonTitle}
        </Link>
    );
};

export default ForumPostButton;