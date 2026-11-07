import { Route, Routes } from 'react-router-dom'
import { BottomNav } from './components/BottomNav'
import { TopNav } from './components/TopNav'
import HomePage from './pages/HomePage'
import ProductDetailPage from './pages/ProductDetailPage'
import CartPage from './pages/CartPage'
import OrderTrackingPage from './pages/OrderTrackingPage'
import SearchPage from './pages/SearchPage'
import ProfilePage from './pages/ProfilePage'
import WishlistPage from './pages/WishlistPage'
import OrderHistoryPage from './pages/OrderHistoryPage'

export default function App() {
  return (
    <div className="min-h-screen bg-bg">
      <TopNav />
      <main className="pb-24 md:pb-10">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/product/:productId" element={<ProductDetailPage />} />
          <Route path="/cart" element={<CartPage />} />
          <Route path="/tracking/:orderId" element={<OrderTrackingPage />} />
          <Route path="/search" element={<SearchPage />} />
          <Route path="/profile" element={<ProfilePage />} />
          <Route path="/wishlist" element={<WishlistPage />} />
          <Route path="/history" element={<OrderHistoryPage />} />
        </Routes>
      </main>
      <BottomNav />
    </div>
  )
}
