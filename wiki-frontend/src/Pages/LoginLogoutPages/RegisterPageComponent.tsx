import { useState, useEffect } from "react"
import "../../Styles/register.css";
import { Link, useNavigate } from 'react-router-dom';
import { handleRegisterSubmit } from "../../Api/wikiAuthApi";
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { useNotification } from '../../Components/NotificationProvider';

export default function RegisterPageComponent(){
    const { styles } = useStyleContext();
    const [email, setEmail] = useState(null);
    const [username, setUsername] = useState(null);
    const [password, setPassword] = useState(null);
    const [role, setRole] = useState(null);

    const [response, setResponse] = useState(null);
    const [emailInputClass, setEmailInputClass] = useState('register-inputbox');
    const [passwordInputClass, setPasswordInputClass] = useState('register-inputbox');
    const [userInputClass, setUserInputClass] = useState("register-inputbox");
    const [roleDropdownClass, setRoleDropdownClass] = useState("role-dropdown");
    
    const navigate = useNavigate();
    const { showNotification } = useNotification();
    
    const HandleSubmit = (e) => {
        e.preventDefault();
        handleRegisterSubmit(email, username, password, "User")
            .then(response => {
                // Handle the response here
                setResponse(response);
            })
            .catch(error => {
                // Handle errors here
                console.error(error);
            });
    }

    const InputClick = () => {
        setEmailInputClass('register-inputbox');
        setPasswordInputClass('register-inputbox');
        setUserInputClass('register-inputbox');
        setRoleDropdownClass('role-dropdown');
    }
    
    useEffect(()=>{
        if (response?.DuplicateEmail || response?.errors?.Email) {
            setEmailInputClass("register-inputbox wrong-credential")
        }
        if (response?.DuplicateUserName || response?.errors?.Username) {
            setUserInputClass("register-inputbox wrong-credential")
        }
        if (response?.PasswordTooShort || response?.errors?.Password) {
            setPasswordInputClass("register-inputbox wrong-credential")
        }
        if (response?.errors?.Role) {
            setRoleDropdownClass("role-dropdown wrong-credential");
        }
        if (response?.userName) {
            showNotification('Succesfully registered!');
            navigate('/');

        }
        
    },[response])

    return(
        <div className="article" style={{backgroundColor: styles.articleColor, padding: '2rem', maxWidth: '500px', margin: '2rem auto'}}>
            <div style={{ width: '100%' }}>
                <form onSubmit={HandleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>
                    <h2 style={{ margin: '0 0 0.5em 0', fontSize: '1.5em', fontWeight: 'bold' }}>Register</h2>
                    <div>
                        <input type="text" required value={email || ''} onChange={(e) => setEmail(e.target.value)} placeholder="Email"
                            style={{ width: '100%', padding: '0.5em', fontSize: '1em', border: '1px solid #ccc', borderRadius: '3px', boxSizing: 'border-box' }} />
                        {response?.DuplicateEmail && <p style={{ color: 'red', margin: '0.25em 0 0', fontSize: '0.85em' }}>Email already in use</p>}
                    </div>
                    <div>
                        <input type="text" required value={username || ''} onChange={(e) => setUsername(e.target.value)} placeholder="Username"
                            style={{ width: '100%', padding: '0.5em', fontSize: '1em', border: '1px solid #ccc', borderRadius: '3px', boxSizing: 'border-box' }} />
                        {response?.DuplicateUserName && <p style={{ color: 'red', margin: '0.25em 0 0', fontSize: '0.85em' }}>Username already in use</p>}
                    </div>
                    <div>
                        <input type="password" required value={password || ''} onChange={(e) => setPassword(e.target.value)} placeholder="Password"
                            style={{ width: '100%', padding: '0.5em', fontSize: '1em', border: '1px solid #ccc', borderRadius: '3px', boxSizing: 'border-box' }} />
                        {response?.PasswordTooShort && <p style={{ color: 'red', margin: '0.25em 0 0', fontSize: '0.85em' }}>Password must be at least 6 characters</p>}
                    </div>
                    <button type="submit" className="modular-button" style={{ backgroundColor: styles.articleColor, border: '1px solid ' + styles.footerListLinkTextColor, borderRadius: '3px', padding: '0.5em 1em', color: '#fff', cursor: 'pointer', fontSize: '0.9em', alignSelf: 'flex-start' }}>Register</button>
                    <p style={{ margin: 0, fontSize: '0.9em' }}>
                        Already have an account? <Link to="/login" style={{ color: styles.footerListLinkTextColor }}>Login here!</Link>
                    </p>
                </form>
            </div>
        </div>
    )
}