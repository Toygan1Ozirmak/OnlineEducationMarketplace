// auth.js
export const isAuthenticated = () => {
    // Kullanıcının giriş yapmış olup olmadığını kontrol et
    const isLoggedIn = localStorage.getItem("isLoggedIn") === "true";
    return isLoggedIn;
};

