import ManualEditStylesComponent from "../Components/ManualEditStylesComponent";
import "../Styles/stylepage.css";
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useStyleContext } from "../Components/contexts/StyleContext";

const EditStylePage = () =>{
    const navigate = useNavigate();
    const { styles, updateStyles, setStyles } = useStyleContext();

    const [newStyles, setNewStyles] = useState(styles);

    const handleChange = (field, value) => {
        // console.log(`${field} ${value}`);
        setNewStyles((prevStyles) => ({ ...prevStyles, [field]: value }));
        // console.log(newStyles[field]);
    };

    const handleUpdate = () => {
        console.log("Handle Update clicked");
        updateStyles(newStyles);
        setStyles(newStyles);
        navigate('/');
    };

    return (
        <div className="stylepage">
            <ManualEditStylesComponent handleChange={handleChange} newStyles={newStyles}/>
            <button onClick={handleUpdate}>Update</button>
        </div>    
    )
}

export default EditStylePage;