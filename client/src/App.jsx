

import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginSignup from "./pages/LoginSignup";
import LandingPage from "./LandingPage/LandingPage";

function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/login" element={<LoginSignup />} />

    </Routes>
  </BrowserRouter>
  );
}

export default App; 
