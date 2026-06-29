
import { useNavigate } from 'react-router-dom';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { useNotification } from '../../../Components/NotificationProvider';
import '../Styles/modularbutton.css';

const ForumPostButton = ({ buttonTitle, linkTo, jwtToken }) => {
    const { styles } = useStyleContext();
    const { showNotification } = useNotification();
    const navigate = useNavigate()

    const handleClick = () => {
        if (!jwtToken) { // Assuming `jwtToken.user` is null when the user is not logged in
            showNotification('You need to log in to perform this action.');
        } else {
            navigate(linkTo)
        }
    };

    return (
        <button onClick={handleClick} className="modular-button" style={{ backgroundColor: styles.articleColor }}>
            {buttonTitle}
        </button>
    );
};

export default ForumPostButton;
