import React, { useLayoutEffect } from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import Home from "./components/Home";
import Login from "./components/Login";
import Register from "./components/Register";

function App() {

  useLayoutEffect(() => {
    
    const verifyToken = async () => {
      const response = await fetch("http://localhost:5000/api/users/verify", {
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
      });
      if (response.status !== 200) {
        localStorage.setItem("authenticated", false)
        localStorage.setItem("username", false);
      } else {
        try {
          var data = await response.text();
          localStorage.setItem("authenticated", true)
          localStorage.setItem("username", data);
        } catch (err) {
          console.log(err);
        }
      }
    };
    verifyToken();
  }, []);

  return (
    <div className="App">
        <BrowserRouter>
          <Switch>
            <Route exact path="/" component={Home} />
            <Route exact path="/login" component={Login} />
            <Route exact path="/register" component={Register} />
          </Switch>
        </BrowserRouter>
    </div>
  );
}

export default App;
