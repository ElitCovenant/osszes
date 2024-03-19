export default function jwt_decode(token) {
  try {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map((char) => {
      return '%' + ('00' + char.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    const decodedToken = JSON.parse(jsonPayload);
    const cleanDecodedToken = {};

    Object.keys(decodedToken).forEach(key => {
      const cleanKey = key.split('/').pop(); // Csak az utolsó részt tartjuk meg
      cleanDecodedToken[cleanKey] = decodedToken[key];
    });

    return cleanDecodedToken;
  } catch (error) {
    console.error('Error decoding JWT token:', error);
    return null;
  }
}