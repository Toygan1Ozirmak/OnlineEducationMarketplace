import axios from "axios";

const BASE_URL = "http://localhost:7280";

export const registerUser = async (formData) => {
    try {
        const response = await axios.post(`${BASE_URL}/api/authentication/register`, formData);
        console.log("Register Response:", response);
        return response.data; // Return the response data for further handling in components
    } catch (error) {
        console.error("Register Error:", error);
        throw error; // Throw an error to handle it in components
    }
};

//export const loginUser = async (formData) => {
//    try {
//        const response = await axios.post(`${BASE_URL}/api/users/Create`, formData);
//        return response.data; // Return the response data for further handling in components
//    } catch (error) {
//        throw error; // Throw an error to handle it in components
//    }
//};

//export const changePasswordUser = async (formData) => {
//    try {
//        const response = await axios.post(`${BASE_URL}/api/users/Create`, formData);
//        return response.data; // Return the response data for further handling in components
//    } catch (error) {
//        throw error; // Throw an error to handle it in components
//    }
//};