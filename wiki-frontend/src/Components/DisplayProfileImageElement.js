import React, {useState, useEffect} from 'react';
import { getProfilePicture } from '../Api/wikiUserApi';
import "../Styles/profilepage.css";

function DisplayProfileImageElement({profilePicture}) {
    const defaultImageUrl = 'https://upload.wikimedia.org/wikipedia/commons/1/1e/Default-avatar.jpg'; 
    const [imageSrc, setImageSrc] = useState(defaultImageUrl);

    useEffect(()=>{
        if (profilePicture) {
            // Fetch profile picture when the component mounts or profilePicture prop changes
            getProfilePicture(profilePicture)
                .then(data => {
                    const imageUrl = URL.createObjectURL(data);

                    setImageSrc(imageUrl);
                })
                .catch(error => {
                    console.error('Error fetching profile picture:', error);
                    // Use default image URL in case of error
                    setImageSrc('https://upload.wikimedia.org/wikipedia/commons/1/1e/Default-avatar.jpg');
                });
        }
    },[profilePicture])


    return (
        <div className='profile-picture-container'>
            <img src={imageSrc} alt="Uploaded" className='profile-picture'/>
        </div>
    );
}

export default DisplayProfileImageElement;