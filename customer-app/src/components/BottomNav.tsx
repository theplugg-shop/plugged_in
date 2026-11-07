import { Home, Search, ShoppingBag, User } from 'lucide-react'
import { NavLink } from 'react-router-dom'
import { useCart } from '@/context/CartContext'
import { cn } from '@/lib/cn'

const navItems = [
  { to: '/', label: 'Home', icon: Home },
  { to: '/search', label: 'Search', icon: Search },
  { to: '/cart', label: 'Cart', icon: ShoppingBag },
  { to: '/profile', label: 'Profile', icon: User },
]

export function BottomNav() {
  const { itemCount } = useCart()

  return (
    <nav className="fixed inset-x-0 bottom-0 flex justify-between border-t border-line bg-surface px-6 py-3 md:hidden">
      {navItems.map(({ to, label, icon: Icon }) => (
        <NavLink
          key={to}
          to={to}
          className={({ isActive }) =>
            cn(
              'relative flex flex-1 flex-col items-center gap-1 text-[10px] font-bold text-muted',
              isActive && 'text-ink',
            )
          }
        >
          <Icon size={20} strokeWidth={2} />
          {label}
          {label === 'Cart' && itemCount > 0 && (
            <span className="absolute -right-1 -top-1 flex h-4 min-w-4 items-center justify-center rounded-full bg-volt px-1 text-[9px] font-extrabold text-volt-ink">
              {itemCount}
            </span>
          )}
        </NavLink>
      ))}
    </nav>
  )
}
