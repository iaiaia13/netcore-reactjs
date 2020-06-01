import React, { Component } from "react";
import logo from "./logo.svg";
import "./App.css";
import { Header } from "semantic-ui-react";

const axios = require("axios");

interface App {
  items: [];
}

class App extends React.Component {
  state = { items: [] };

  componentDidMount() {
    this.getItems();
  }

  getItems() {
    axios.get("http://localhost:5000/api/values").then((res: any) => {
      this.setState({
        items: res.data,
      });
    });
  }

  render() {
    return (
      <div className="App">
        <Header as="h2">
          Account Settings
          <Header.Subheader>
            Manage your account settings and set email preferences
          </Header.Subheader>
        </Header>
      </div>
    );
  }
}

export default App;
