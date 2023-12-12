import React, { Component } from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import { isAuthenticated } from './auth';



export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Routes>
                    {AppRoutes.map((route, index) => {
                        const { path, ...rest } = route;
                        return (
                            <Route key={index} path={path} {...rest} element={route.element} />
                        );
                    })}
                </Routes>
            </Layout>
        );
    }
}
