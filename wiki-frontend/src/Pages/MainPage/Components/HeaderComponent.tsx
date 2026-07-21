import React, { useEffect, useRef, useState } from "react";
import { Link } from 'react-router-dom';
import { useSiteSettings } from '../../../Components/contexts/SiteSettingsContext';
import { getLogo } from "../../../Api/wikiApi";
import '../Styles/headercomponent.css';
const HeaderComponent = ({userName, userRole, children}) => { 
    const { settings } = useSiteSettings();
    const [imageSrc, setImageSrc] = useState("/img/logo.png");
    const [title, setTitle] = useState("Default Title");
    const blobUrlRef = useRef(null);

    useEffect(()=>{
        if (settings?.logo && settings.logo !== 'logo_pfp.png') {
            setTitle(settings.wikiName || 'WikiPOC');
            getLogo(settings.logo)
                .then(data => {
                    if (data instanceof Blob) {
                        if (blobUrlRef.current) URL.revokeObjectURL(blobUrlRef.current);
                        const imageUrl = URL.createObjectURL(data);
                        blobUrlRef.current = imageUrl;
                        setImageSrc(imageUrl);
                    } else if (typeof data === 'string' && data.startsWith('blob:')) {
                        setImageSrc(data);
                    } else {
                        console.error('Invalid profile picture data:', data);
                        throw new Error('Invalid profile picture data');
                    }
                })
                .catch(error => {
                    console.error('Error fetching profile picture:', error);
                    setImageSrc("/img/logo.png");
                });
        }
    },[settings?.logo, settings?.wikiName])

    return (
        <div className="top-header">
            {children}
            <div className="logo-container">
                <Link to="/"><img src={imageSrc} alt="logo" className="site-logo" width="100" height="100" /></Link>
            </div>
            <div className="title-container">
                <Link to="/"><h1 className="page-title">{title}</h1></Link>
            </div>
            <div className="headerLinks">{userName && <a href={`/profile/${userName}`}>{userName}</a>} {userRole}</div>
        </div>
    );
}

export default HeaderComponent;
