import React, { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';
import LoginPage from "./components/LoginPage/LoginPage";
import Register from "./components/Register/Register";
import HomePage from "./components/HomePage/HomePage";
import Shop from "./components/Shop/Shop";
import { isAuthenticated } from "./auth";
import MachineLearningPage from "./components/Categories/MachineLearning/MachineLearning";
import CourseDetail from "./components/CourseDetail/CourseDetail";
import UIUXPage from "./components/Categories/UI-UX/UI-UX";
import SoftwareTestingPage from "./components/Categories/SoftwareTesting/SoftwareTesting";

const PrivateRouteHomePage = () => {
    const navigate = useNavigate();
    const [authenticated, setAuthenticated] = useState(isAuthenticated());

    useEffect(() => {
        if (!authenticated) {
            // Kullanýcý authenticated deðilse, login sayfasýna yönlendir
            navigate('/');
        }
    }, [authenticated, navigate]);

    return authenticated ? <HomePage /> : null;
}

const PrivateRouteShop = () => {
    const navigate = useNavigate();
    const [authenticated, setAuthenticated] = useState(isAuthenticated());

    useEffect(() => {
        if (!authenticated) {
            // Kullanýcý authenticated deðilse, login sayfasýna yönlendir
            navigate('/');
        }
    }, [authenticated, navigate]);

    return authenticated ? <Shop /> : null;
}

const PrivateRouteMachineLearningPage = () => {
    const navigate = useNavigate();
    const [authenticated, setAuthenticated] = useState(isAuthenticated());

    useEffect(() => {
        if (!authenticated) {
            // Kullanýcý authenticated deðilse, login sayfasýna yönlendir
            navigate('/');
        }
    }, [authenticated, navigate]);

    return authenticated ? <MachineLearningPage /> : null;
}

const PrivateRouteCourseDetail = () => {
    const navigate = useNavigate();
    const [authenticated, setAuthenticated] = useState(isAuthenticated());

    useEffect(() => {
        if (!authenticated) {
            // Kullanýcý authenticated deðilse, login sayfasýna yönlendir
            navigate('/');
        }
    }, [authenticated, navigate]);

    return authenticated ? <CourseDetail /> : null;
}

const PrivateRouteUIUXPage = () => {
    const navigate = useNavigate();
    const [authenticated, setAuthenticated] = useState(isAuthenticated());

    useEffect(() => {
        if (!authenticated) {
            // Kullanýcý authenticated deðilse, login sayfasýna yönlendir
            navigate('/');
        }
    }, [authenticated, navigate]);

    return authenticated ? <UIUXPage /> : null;
}

const PrivateRouteSoftwareTestingPage = () => {
    const navigate = useNavigate();
    const [authenticated, setAuthenticated] = useState(isAuthenticated());

    useEffect(() => {
        if (!authenticated) {
            // Kullanýcý authenticated deðilse, login sayfasýna yönlendir
            navigate('/');
        }
    }, [authenticated, navigate]);

    return authenticated ? <SoftwareTestingPage /> : null;
}

const AppRoutes = [
    {
        path: "/",
        index: true,
        element: <LoginPage />,
    },
    {
        path: "/register",
        element: <Register />,
    },
    {
        path: "/homepage",
        element: <PrivateRouteHomePage />,
    },
    {
        path: "/shop",
        element: <PrivateRouteShop />,
    },
    {
        path: "/shop/machine-learning",
        element: <PrivateRouteMachineLearningPage />,
    },
    {
        path: "/course/:courseId",
        element: <PrivateRouteCourseDetail />,
    },
    {
        path: "/shop/ui-ux",
        index: true,
        element: <PrivateRouteUIUXPage />,
    },
    {
        path: "/shop/software-testing",
        index: true,
        element: <PrivateRouteSoftwareTestingPage />,
    },
    //{
    //    path: '/changepassword',
    //    element: <ChangePassword />
    //},
    //{
    //    path: '/myprofile',
    //    element: <MyProfile />
    //},
    //{
    //    path: '/basket',
    //    element: <Basket />
    //}
];

export default AppRoutes;