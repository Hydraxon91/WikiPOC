import ProfileElement from "../Components/ProfileElement";
import { useParams } from 'react-router-dom';
import { useEffect, useState } from "react";
import { useUserContext } from '../Components/contexts/UserContextProvider';
import { getUserProfileByUsername } from "../Api/wikiUserApi";
import "../Styles/profilepage.css";

const ProfilePage = () => {
    const {decodedTokenContext} = useUserContext();
    const { username } = useParams();
    const [userProfile, setUserProfile] = useState(null);
    const [isYourProfile, setIsYourProfile] = useState(false);

    useEffect(() => { 
        if (username!==null) {
            getUserProfileByUsername(username, setUserProfile);
        }
    }, [username]);

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        decodedTokenName && (username === decodedTokenName && setIsYourProfile(true));
    }, [decodedTokenContext]);

    return (
        <div className="profilepage">
            {userProfile?.userName && <ProfileElement user={userProfile} canEdit={isYourProfile}/>}
        </div>
    )
}

export default ProfilePage;