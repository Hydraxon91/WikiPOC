import React from 'react';
import { Link } from 'react-router-dom';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import '../Styles/modularbutton.css';

const ForumPostButton = ({ buttonTitle, linkTo }) => {
    const {styles} = useStyleContext();
    return (
        <Link to={linkTo} className="modular-button" style={{backgroundColor: styles.articleColor}}>
            {buttonTitle}
        </Link>
    );
};

export default ForumPostButton;