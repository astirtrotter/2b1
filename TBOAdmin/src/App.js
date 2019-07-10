import React, { Component } from 'react';
import { Router, Route, Switch } from 'react-router-dom';
import {connect} from "react-redux";
import { history } from './_helpers';
// import { renderRoutes } from 'react-router-config';
import './App.scss';
import {alertActions} from "./_actions";
import {UncontrolledAlert} from "reactstrap";

const loading = () => <div className="animated fadeIn pt-3 text-center">Loading...</div>;

// Containers
const DefaultLayout = React.lazy(() => import('./containers/DefaultLayout'));

// Pages
const Login = React.lazy(() => import('./pages/auth/Login'));
const Register = React.lazy(() => import('./pages/auth/Register'));
// const Page404 = React.lazy(() => import('./views/Pages/Page404'));
// const Page500 = React.lazy(() => import('./views/Pages/Page500'));
const AuthorizedRoute = React.lazy(() => import('./components/AuthorizedRoute'));

class App extends Component {
  constructor(props) {
    super(props);

    history.listen((location, action) => {
      // clear alerts on location change
      this.dismissAlert();
    });

    this.dismissAlert = this.dismissAlert.bind(this);
  }

  dismissAlert() {
    const {dispatch} = this.props;
    dispatch(alertActions.clear());
  }

  render() {
    const {alert} = this.props;
    return (
      <Router history={history}>
        <React.Suspense fallback={loading()}>
          {
            alert.message &&
            <UncontrolledAlert color={alert.type} toggle={this.dismissAlert}>{alert.message}</UncontrolledAlert>
          }
          <UncontrolledAlert color="danger" style={{position: 'fixed', width:'100%'}}>Danger Alert</UncontrolledAlert>
          <Switch>
            <Route exact path="/login" name="Login Page" render={props => <Login {...props}/>}/>
            <Route exact path="/register" name="Register Page" render={props => <Register {...props}/>}/>
            {/*<Route exact path="/404" name="Page 404" render={props => <Page404 {...props}/>} />*/}
            {/*<Route exact path="/500" name="Page 500" render={props => <Page500 {...props}/>} />*/}
            <Route path="/" name="Home" render={props => <DefaultLayout {...props}/>}/>
          </Switch>
        </React.Suspense>
      </Router>
    );
  }
}

function mapStateToProps(state) {
  const {alert} = state;
  return {alert};
}

export default connect(mapStateToProps)(App);
