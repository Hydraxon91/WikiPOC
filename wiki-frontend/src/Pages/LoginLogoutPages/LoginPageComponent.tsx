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
    const [emailInputClass, setEmailInputClass] = useState('login-inputbox');
    const [passwordInputClass, setPasswordInputClass] = useState('login-inputbox');
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

    const InputClick = () => {
        setEmailInputClass('login-inputbox');
        setPasswordInputClass('login-inputbox');
    }
    
    useEffect(()=>{
        if (response) {
            if (response?.token) {
                login(response.token);
                showNotification('Succesfully logged in!');
                navigate('/');
            }
            else{
                setEmailInputClass('login-inputbox wrong-credential');
                setPasswordInputClass('login-inputbox wrong-credential');
            }
        }
        
    },[response])

    return(
        <div className='login-form' style={{ background: styles.bodyColor ? `linear-gradient(to bottom, ${styles.bodyColor}, ${styles.articleColor})` : '', '--text-color': styles.footerListTextColor, '--link-color': styles.footerListLinkTextColor, '--accent-color': styles.articleColor } as any}>
            <div>
                <form onSubmit={HandleSubmit}>
                    <h2 className="login-text">Login</h2>
                    <div className="login-inputboxholder">
                        <div className={emailInputClass}>
                            <input type="text" required onClick={InputClick} onChange={(e) => setEmail(e.target.value)}></input>
                            <label htmlFor="emailInput">Email/Username</label>
                            <h3 className="invalid-email-text">invalid email or username</h3>
                        </div>
                        <div className={passwordInputClass}>
                            <input type="password" required onClick={InputClick} onChange={(e) => setPassword(e.target.value)}></input>
                            <label htmlFor="passwordInput">Password</label>
                            <h3 className="invalid-password-text">invalid password</h3>
                        </div>
                    </div>
                    <div className="forget">
                            <a href="https://www.youtube.com/watch?v=dQw4w9WgXcQ"> Forgot Password?</a>
                    </div>
                    <button type="submit" className="login-button">Login</button>
                    <div className="register">
                        <p>
                            Don't have an account? 
                            <Link to="/register"> Register here!</Link>
                        </p>
                    </div>
                </form>
            </div>
        </div>
    )
}