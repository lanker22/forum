import React, { useState } from 'react';
import { BrowserRouter, Switch, Route } from "react-router-dom";
import UserContext from "./components/UserContext";
import Home from "./components/Home";
import Login from "./components/Login";

function App() {

  const [isAuthenticated, setIsAuthenticated] = useState(false);

  return (
      <div className="App">
        <UserContext.Provider value={{ isAuthenticated, setIsAuthenticated }}>
          <BrowserRouter>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route exact path="/login" component={Login} />
            </Switch>
          </BrowserRouter>
        </UserContext.Provider>
      </div>
  );
}

export default App;
