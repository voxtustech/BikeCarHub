import React, {
    createContext,
    useContext,
    useEffect,
    useState
} from "react";

import {
    login as loginApi,
    logout as logoutApi,
    currentUser
} from "../api/authApi";

const AuthContext = createContext();

export function AuthProvider({ children }) {

    const [user, setUser] = useState(null);

    const [loading, setLoading] = useState(true);

    useEffect(() => {

        async function loadUser() {

            try {

                const data = await currentUser();

                setUser(data.user);

            }
            catch {

                setUser(null);
                return data.user;
            }
            finally {

                setLoading(false);

            }

        }

        loadUser();

    }, []);

    async function login(credentials) {

        const data = await loginApi(credentials);

        setUser(data.user);

        return data.user;

    }

    async function logout() {

        await logoutApi();

        setUser(null);

    }

    return (

        <AuthContext.Provider

            value={{

                user,

                loading,

                login,

                logout,

                isAuthenticated: !!user

            }}

        >

            {children}

        </AuthContext.Provider>

    );

}

export function useAuth() {

    return useContext(AuthContext);

}