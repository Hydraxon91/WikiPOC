import { useState, useEffect } from "react"
import "../../Styles/login.css";
import { jwtDecode } from 'jwt-decode';
import { Link, useNavigate } from 'react-router-dom';
import { handleLoginSubmit } from "../../Api/wikiAuthApi";
import { useStyleContext } from '../../Components/contexts/StyleContext';
import { useNotification } from '../../Components/NotificationProvider';

export default function LoginPageComponent({handleLogin}){
    const { styles } = useStyleContext();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [response, setResponse] = useState(null);
    const navigate = useNavigate();
    const { showNotification } = useNotification();
    
    const login = (jwt_token) => {
        const decoded = jwtDecode(jwt_token);
        const expirationTimestamp = Number(decoded.exp);
        const expirationDate = new Date(Number(expirationTimestamp) * 1000)
        handleLogin(jwt_token, expirationDate);
    }

    const HandleSubmit = (e) => {
        e.preventDefault();
        handleLoginSubmit(email, password)
            .then(response => {
                setResponse(response);
            })
            .catch(error => {
                console.error(error);
            });
    }

    useEffect(()=>{
        if (response) {
            if (response?.token) {
                login(response.token);
                showNotification('Succesfully logged in!');
                navigate('/');
            }
        }
        
    },[response])

    return(
        <div className="article" style={{backgroundColor: styles.articleColor, padding: '2rem', maxWidth: '500px', margin: '2rem auto'}}>
            <div style={{ width: '100%' }}>
                <form onSubmit={HandleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>
                    <h2 style={{ margin: '0 0 0.5em 0', fontSize: '1.5em', fontWeight: 'bold' }}>Login</h2>
                    <div>
                        <input type="text" required value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Email/Username"
                            style={{ width: '100%', padding: '0.5em', fontSize: '1em', border: '1px solid #ccc', borderRadius: '3px', boxSizing: 'border-box' }} />
                    </div>
                    <div>
                        <input type="password" required value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Password"
                            style={{ width: '100%', padding: '0.5em', fontSize: '1em', border: '1px solid #ccc', borderRadius: '3px', boxSizing: 'border-box' }} />
                    </div>
                    {response && !response.token && (
                        <p style={{ color: 'red', margin: 0, fontSize: '0.9em' }}>Invalid email or password</p>
                    )}
                    <button type="submit" className="modular-button" style={{ backgroundColor: styles.articleColor, border: '1px solid ' + styles.footerListLinkTextColor, borderRadius: '3px', padding: '0.5em 1em', color: '#fff', cursor: 'pointer', fontSize: '0.9em', alignSelf: 'flex-start' }}>Login</button>
                    <p style={{ margin: 0, fontSize: '0.9em' }}>
                        Don't have an account? <Link to="/register" style={{ color: styles.footerListLinkTextColor }}>Register here!</Link>
                    </p>
                </form>
            </div>
        </div>
    )
}