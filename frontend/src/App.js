import React, { useState, useEffect } from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import UserContext from "./components/UserContext";
import Home from "./components/Home";
import Login from "./components/Login";
import Register from "./components/Register";

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [applicationUser, setApplicationUser] = useState("");

  useEffect(() => {
    const verifyToken = async () => {
      const response = await fetch("http://localhost:5000/api/users/verify", {
        credentials: "include",
      });
      if (response.status !== 200) {
        setIsAuthenticated(false);
        setApplicationUser("");
      } else {
        try {
          var data = await response.json();
          console.log(data);
        } catch (err) {
          console.log(err);
        }
      }
    };
    verifyToken();
  }, []);

  return (
    <div className="App">
      <UserContext.Provider
        value={{
          auth: [isAuthenticated, setIsAuthenticated],
          user: [applicationUser, setApplicationUser],
        }}
      >
        <BrowserRouter>
          <Switch>
            <Route exact path="/" component={Home} />
            <Route exact path="/login" component={Login} />
            <Route exact path="/register" component={Register} />
          </Switch>
        </BrowserRouter>
      </UserContext.Provider>
    </div>
  );
}

export default App;
