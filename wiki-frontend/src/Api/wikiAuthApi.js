const BASE_URL = 'http://localhost:5000';

export const handleLoginSubmit = async (email, password) => {
    const data = {
        email: email,
        password: password,
    }
    const response = await fetch(`${BASE_URL}/api/Auth/Login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
        });
    const responseData = await response.json();
    return responseData;
};