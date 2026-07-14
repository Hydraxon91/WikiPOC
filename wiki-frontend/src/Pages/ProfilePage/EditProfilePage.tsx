import ProfileEditorElement from './Components/ProfileEditorElement';
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from "react";
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { getUserProfileByUsername } from '../../Api/wikiUserApi';
import { useStyleContext } from '../../Components/contexts/StyleContext';

const EditProfilePage = ({jwtToken}) => {
    const {decodedTokenContext} = useUserContext();
    const {styles} = useStyleContext();
    const navigate = useNavigate();
    const { username } = useParams();
    const [validateProfile, setValidateProfile] = useState(false);
    const [userProfile, setUserProfile] = useState(null);

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        if (decodedTokenName) {
            if (username === decodedTokenName) {
                setValidateProfile(true);
                getUserProfileByUsername(username, setUserProfile);
            } else {
                navigate("/");
            }
        }
    }, [decodedTokenContext, username, navigate]);

    return (
        <div className="profilepage article" style={{backgroundColor: styles.articleColor}}>
            {validateProfile && userProfile ? 
            (
                <ProfileEditorElement user={userProfile} jwtToken={jwtToken}/>
            ) : null}
        </div>
    )
}

export default EditProfilePage;