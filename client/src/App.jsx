

import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginSignup from "./pages/LoginSignup";
import HomePage from './HomePage/homePage';
import LandingPage from "./LandingPage/LandingPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginSignup />} />
        <Route path="/home" element={<HomePage/>} />
      </Routes>
  </BrowserRouter>
  );
}

export default App; 
