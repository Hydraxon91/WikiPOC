import {useState, useEffect, useRef} from 'react';
import { getProfilePicture } from '../../../Api/wikiUserApi';
import "../../../Styles/profilepage.css";

function DisplayProfileImageElement({profilePicture, classNameProp}: {profilePicture?: string; classNameProp?: string}) {
    const defaultImageUrl = 'https://upload.wikimedia.org/wikipedia/commons/1/1e/Default-avatar.jpg'; 
    const [imageSrc, setImageSrc] = useState(defaultImageUrl);
    const blobUrlRef = useRef<string | null>(null);

    useEffect(()=>{
        if (profilePicture) {
            if (profilePicture.startsWith('blob:')) {
                try {
                    const url = new URL(profilePicture);
                    if (url.origin === window.location.origin) {
                        setImageSrc(profilePicture);
                    } else {
                        setImageSrc(defaultImageUrl);
                    }
                } catch {
                    setImageSrc(defaultImageUrl);
                }
                return;
            }

            getProfilePicture(profilePicture)
                .then(data => {
                    if (data instanceof Blob) {
                        if (blobUrlRef.current) URL.revokeObjectURL(blobUrlRef.current);
                        const imageUrl = URL.createObjectURL(data);
                        blobUrlRef.current = imageUrl;
                        setImageSrc(imageUrl);
                    } else {
                        console.error('Invalid profile picture data:', data);
                        setImageSrc(defaultImageUrl);
                    }
                })
                .catch(() => {
                    setImageSrc(defaultImageUrl);
                });
        }
    },[profilePicture])

    return (
        <div className={classNameProp}>
            <img src={imageSrc} alt="Uploaded"/>
        </div>
    );
}

export default DisplayProfileImageElement;