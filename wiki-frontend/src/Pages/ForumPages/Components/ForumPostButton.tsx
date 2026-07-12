
import { useNavigate } from 'react-router-dom';
import { useStyleContext } from '../../../Components/contexts/StyleContext';
import { useNotification } from '../../../Components/NotificationProvider';
import EraAwareButton from '../../../Components/LiquidGlassButton/EraAwareButton';

const ForumPostButton = ({ buttonTitle, linkTo, jwtToken }) => {
    const { styles } = useStyleContext();
    const { showNotification } = useNotification();
    const navigate = useNavigate()

    const handleClick = () => {
        if (!jwtToken) {
            showNotification('You need to log in to perform this action.');
        } else {
            navigate(linkTo)
        }
    };

    return (
        <EraAwareButton
            onClick={handleClick}
            style={{ backgroundColor: styles.articleColor }}
        >
            {buttonTitle}
        </EraAwareButton>
    );
};

export default ForumPostButton;
