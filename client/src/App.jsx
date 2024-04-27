

import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginSignup from "./pages/LoginSignup";
import HomePage from './HomePage/homePage';
import LandingPage from "./LandingPage/LandingPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
<<<<<<< HEAD
        <Route path="/" element={<HomePage />} />
        <Route path="/ia" element={<HomePage/>}/>

=======
        <Route path="/login" element={<LoginSignup />} />
        <Route path="/home" element={<HomePage/>} />
        <Route path="/landingPage" element={<LandingPage/>} />
>>>>>>> 2ba18869f848499ca1d71efcd6dc3613a3b21b68
      </Routes>
  </BrowserRouter>
  );
}

export default App; 
