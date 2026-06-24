import React, { useEffect, useRef, useState } from "react";
import { Link } from 'react-router-dom';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { getLogo } from "../../../Api/wikiApi";
import '../Styles/headercomponent.css';
const HeaderComponent = ({userName, userRole}) => { 
    const { styles }  = useStyleContext();
    const [imageSrc, setImageSrc] = useState("/img/logo.png");
    const [title, setTitle] = useState("Default Title");
    const blobUrlRef = useRef(null);

    useEffect(()=>{
        if (styles && styles.logo) {
            setTitle(styles.wikiName);
            getLogo(styles.logo)
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
    },[styles.logo])

    return (
        <div className="top-header" style={{ background: styles.bodyColor ? `linear-gradient(to bottom, ${styles.bodyColor}, ${styles.articleColor})` : '' }}>
            <div className="logo-container">
                <Link to="/"><img src={imageSrc} alt="logo" className="site-logo"/></Link>
            </div>
            <div className="title-container">
                <h1 className="page-title">{title}</h1>
            </div>
            <div className="headerLinks"><a href={`/profile/${userName}`}>{userName}</a> {userRole}</div>
        </div>
    );
}

export default HeaderComponent;