import ManualEditStylesComponent from "../Components/ManualEditStylesComponent";
import PresetsComponent from "../Components/PresetsComponent";
import "../Styles/stylepage.css";
import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useStyleContext } from "../Components/contexts/StyleContext";

const EditStylePage = () =>{
    const navigate = useNavigate();
    const { styles, updateStyles, setStyles } = useStyleContext();

    const [newStyles, setNewStyles] = useState(styles);
    const [backUpStyles, setBackupStyles] = useState(styles);
    const [manualEdit, setManualEdit] = useState(false);
    const [leave, setLeave] = useState(false);
    
    useEffect(()=>{
        setStyles(newStyles)
        return () => {
            setStyles(backUpStyles);
        };
    },[newStyles, backUpStyles, setStyles]);

    useEffect(()=>{
        console.log(manualEdit);
    },[manualEdit])

    useEffect(()=>{
        leave && navigate("/");
    },[leave])

    const handleChange = (field, value) => {
        setNewStyles((prevStyles) => ({ ...prevStyles, [field]: value }));
    };


    const handleUpdate = () => {
        console.log("Handle Update clicked");
        updateStyles(newStyles);
        setStyles(newStyles);
        setBackupStyles(prevStyles => ({ ...prevStyles, ...newStyles }));
        setLeave(true);
    };

    return (
        <div className="stylepage">
            {manualEdit ? 
                <ManualEditStylesComponent handleChange={handleChange} newStyles={newStyles}/>
                :
                <PresetsComponent handleChange={handleChange} logo={styles.logo}></PresetsComponent>    
            }
            <button onClick={handleUpdate}>Update</button>
            <button onClick={()=>setManualEdit(!manualEdit)}>{manualEdit ? "Presets" : "Manual Edit"}</button>
        </div>    
    )
}

export default EditStylePage;