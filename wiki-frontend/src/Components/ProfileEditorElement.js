import { useState, useEffect } from "react"
import { useNavigate } from "react-router-dom";
import DisplayProfileImageElement from "./DisplayProfileImageElement"
import "../Styles/profilepage.css";
import { postProfileEdit } from "../Api/wikiUserApi";

const ProfileEditorElement = ({user, cookies}) => {
    const[profilePicture, setProfilePicture] = useState(null);
    const[displayName, setDisplayName] = useState(null);
    const navigate = useNavigate();

    const handleDisplayNameChange = (event) => {
      setDisplayName(event.target.value);
    };

    const handlePfpLinkChange = (event) => {
      setProfilePicture(event.target.value);
    };

    const handleSubmit = async (e) =>{
      e.preventDefault();
      const newProfile = {
        ...user,
        displayName: displayName,
        profilePicture: profilePicture
      }

      try {
        await postProfileEdit(newProfile, cookies);
        alert('Successfully submitted profile update');
        navigate(`/profile/${newProfile.userName}`)
    } catch (error) {
        console.error('Error updating profile:', error);
    }
      
    };

      useEffect(()=>{
        // console.log(user);
        if (user?.displayName) {
          setProfilePicture(user.profilePicture);
          if (user.profilePicture) {
            setProfilePicture(user.profilePicture);
          }
          setDisplayName(user.displayName);
        }
      },[user])

    return (
        <form className="profile-container">
            <div className="profilepic-container-container">
                <DisplayProfileImageElement profilePicture={profilePicture} />
             </div>
             <div className="user-info">
                <p>Profile Picture: </p>
                <input className="edit-displayname" type="text" value={profilePicture} onChange={handlePfpLinkChange}/>
             </div>
             
             <div className="user-info"><p>Username: {user?.userName}</p></div>
             <div className="user-info"> 
                <p>Display name: </p>
                <input className="edit-displayname" type="text" value={displayName} onChange={handleDisplayNameChange}></input>
              </div>
             <button className="edit-profile-button" onClick={handleSubmit}>Submit Changes</button>
        </form>
    );
}

export default ProfileEditorElement;