import axios from "axios";

const BASE_URL = "https://localhost:7280";

export const registerUser = async (formData) => {
   
    try {
        const jsonData = JSON.stringify(formData);

        const xhr = new XMLHttpRequest();
        xhr.open("POST", `https://localhost:7280/api/authentication/register`, true);
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    console.log("API Response:", xhr.responseText);
                    // Handle the response data if needed
                } else {
                    console.error("Register Error:", xhr.statusText);
                    console.error("Error response:", xhr.responseText);
                    // Throw an error or handle the error in components
                }
            }
        };

        xhr.send(jsonData);

    } catch (error) {
        console.error("Register Error:", error);
        throw error; // Throw an error to handle it in components
    }
};


export const loginUser = async (formData) => {
    return new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();
        xhr.open("POST", `https://localhost:7280/api/authentication/login`, true);
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    const response = JSON.parse(xhr.responseText);
                    console.log("API Response:", response);
                    resolve(response); // Resolve with the parsed response
                } else {
                    console.error("Login Error:", xhr.statusText);
                    console.error("Error response:", xhr.responseText);
                    reject(xhr.statusText); // Reject with the status text
                }
            }
        };

        const jsonData = JSON.stringify(formData);
        xhr.send(jsonData);
    });
};

export const getAllCourses = async () => {
    try {
        const response = await axios.get(`${BASE_URL}/api/courses/GetAllCourses`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const GetCoursesByCategoryId = async (categoryId) => {
    try {
        const response = await axios.get(`${BASE_URL}/api/courses/GetCoursesByCategoryId/category/${categoryId}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const GetCourseByCourseId = async (courseId) => {
    try {
        const response = await axios.get(`${BASE_URL}/api/courses/GetCourseByCourseId/${courseId}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const GetReviewsByCourseId = async (courseId) => {
    try {
        const response = await axios.get(`${BASE_URL}/api/reviews/GetReviewsByCourseId/${courseId}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const CreateReview = async (reviewDto) => {
    try {
        const response = await axios.post(`${BASE_URL}/api/reviews/Create`, reviewDto, {
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const GetVideo = async (courseId) => {
    try {
        const response = await axios.get(`${BASE_URL}/api/S3/GetVideo/${courseId}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const GetImage = async (courseId) => {
    try {
        const response = await axios.get(`${BASE_URL}/api/S3/GetImage/${courseId}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};
