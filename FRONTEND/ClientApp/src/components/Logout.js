// Logout.js

class Logout {
    logoutUser = async () => {
        try {
            // Local storage'dan kullanıcı bilgilerini ve giriş durumunu temizle
            await localStorage.removeItem("userData");
            await localStorage.removeItem("isLoggedIn");

            console.log("User logged out successfully.");
            return true; // Başarıyla çıkış yapıldığını belirtmek için bir değer döndür
        } catch (error) {
            console.error("Logout Error:", error);
            throw error;
        }
    };
}

export const logoutInstance = new Logout();
