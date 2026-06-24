import {useState, useEffect, useRef} from 'react';
import { getProfilePicture } from '../../../Api/wikiUserApi';
import "../../../Styles/profilepage.css";

function DisplayProfileImageElement({profilePicture, classNameProp}: {profilePicture?: string; classNameProp?: string}) {
    const defaultImageUrl = 'https://upload.wikimedia.org/wikipedia/commons/1/1e/Default-avatar.jpg'; 
    const [imageSrc, setImageSrc] = useState(defaultImageUrl);
    const blobUrlRef = useRef(null);

    useEffect(()=>{
        if (profilePicture) {
            getProfilePicture(profilePicture)
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