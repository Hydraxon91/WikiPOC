import ManualEditStylesComponent from "./Components/ManualEditStylesComponent";
import PresetsComponent from "./Components/PresetsComponent";
import "../../Styles/stylepage.css";
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useStyleContext } from "../../Components/contexts/StyleContext";
import { useNotification } from '../../Components/NotificationProvider';

const EditStylePage = ({jwtToken}) =>{
    const navigate = useNavigate();
    const { styles, updateStyles, setStyles } = useStyleContext();
    const { showNotification } = useNotification();

    const[logoPicture, setLogoPicture] = useState(null);
    const [newStyles, setNewStyles] = useState(styles);
    const [backUpStyles, setBackupStyles] = useState(styles);
    const [manualEdit, setManualEdit] = useState(false);
    const [leave, setLeave] = useState(false);
    
    useEffect(()=>{
        setStyles(newStyles)
    }, [newStyles, setStyles]);

    useEffect(() => {
        return () => {
            setStyles(backUpStyles);
        };
    }, [backUpStyles, setStyles]);

    useEffect(()=>{
        leave && navigate("/");
    },[leave])

    const handleChange = (field, value) => {
        setNewStyles((prevStyles) => ({ ...prevStyles, [field]: value }));
    };

    const handleLogoPictureChange = (event) => {
        const file = event.target.files[0];
        setLogoPicture(file);
      };

    const handleUpdate = async () => {
        try {
            await updateStyles(newStyles, logoPicture, jwtToken);
            setStyles(newStyles);
            setBackupStyles(prevStyles => ({ ...prevStyles, ...newStyles }));
            setLeave(true);
        } catch (err) {
            showNotification('Failed to save styles: ' + err.message);
        }
    };

    return (
        <div className="article" style={{backgroundColor: styles.articleColor, padding: '1.5em'}}>
        <div className="stylepage">
            {manualEdit ? 
                <ManualEditStylesComponent handleChange={handleChange} newStyles={newStyles} handleLogoPictureChange={handleLogoPictureChange}/>
                :
                <PresetsComponent handleChange={handleChange} logo={styles.logo}></PresetsComponent>    
            }
            <button onClick={handleUpdate}>Update</button>
            <button onClick={()=>setManualEdit(!manualEdit)}>{manualEdit ? "Presets" : "Manual Edit"}</button>
        </div>
        </div>    
    )
}

export default EditStylePage;