import ProfileEditorElement from './Components/ProfileEditorElement';
import { useParams } from 'react-router-dom';
import { useEffect, useState } from "react";
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { getUserProfileByUsername } from '../../Api/wikiUserApi';

const EditProfilePage = ({cookies}) => {
    const {decodedTokenContext} = useUserContext();
    const { username } = useParams();
    const [validateProfile, setValidateProfile] = useState(false);
    const [userProfile, setUserProfile] = useState(null);

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        // decodedTokenName && (username === decodedTokenName && setValidateProfile(true));
        if (decodedTokenName) {
            if (username === decodedTokenName) {
                setValidateProfile(true);
                getUserProfileByUsername(username, setUserProfile);
            }
        }
    }, [decodedTokenContext]);

    return (
        <div className="profilepage">
            {validateProfile ? 
            (
                <ProfileEditorElement user={userProfile} cookies={cookies}/>
            ) : (
                <div>You have no access to this profile 3:</div>
            )}
        </div>
    )
}

export default EditProfilePage;