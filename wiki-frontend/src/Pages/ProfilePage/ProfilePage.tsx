import ProfileElement from "./Components/ProfileElement";
import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from "react";
import { useUserContext } from '../../Components/contexts/UserContextProvider';
import { getUserProfileByUsername } from "../../Api/wikiUserApi";
import { useStyleContext } from "../../Components/contexts/StyleContext";
import { useNotification } from '../../Components/NotificationProvider';
import "../../Styles/profilepage.css";

const ProfilePage = () => {
    const navigate = useNavigate();
    const {styles} = useStyleContext();
    const {decodedTokenContext} = useUserContext();
    const { username } = useParams();
    const [userProfile, setUserProfile] = useState(null);
    const [isYourProfile, setIsYourProfile] = useState(false);
    const { showNotification } = useNotification();

    useEffect(() => { 
        if (username!==null) {
            getUserProfileByUsername(username, setUserProfile)
            .catch(error => {
                showNotification(`Profile for ${username} doesn't exist.`);
                navigate("/");
            });
        }
    }, [username, navigate]);

    useEffect(() => {
        const decodedTokenName = decodedTokenContext?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        decodedTokenName && (username === decodedTokenName && setIsYourProfile(true));
    }, [decodedTokenContext, username]);

    return (
        <div className="profilepage article" style={{backgroundColor: styles.articleColor, '--accent-color': styles.articleColor, '--footer-link-color': styles.footerListLinkTextColor} as any}>
            {userProfile?.userName && <ProfileElement user={userProfile} canEdit={isYourProfile}/>}
        </div>
    )
}

export default ProfilePage;