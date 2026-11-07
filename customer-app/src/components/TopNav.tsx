import { Heart, History, Search, ShoppingBag, User } from 'lucide-react'
import { NavLink, useNavigate, useSearchParams } from 'react-router-dom'
import { useCart } from '@/context/CartContext'
import { cn } from '@/lib/cn'
import { LogoMark } from './LogoMark'

const iconLinks = [
  { to: '/wishlist', label: 'Likes', icon: Heart },
  { to: '/history', label: 'History', icon: History },
  { to: '/profile', label: 'Profile', icon: User },
]

function IconLinks({ size = 19 }: { size?: number }) {
  const { itemCount } = useCart()

  return (
    <>
      {iconLinks.map(({ to, label, icon: Icon }) => (
        <NavLink
          key={to}
          to={to}
          aria-label={label}
          className={({ isActive }) =>
            cn('text-muted transition-colors hover:text-ink', isActive && 'text-ink')
          }
        >
          <Icon size={size} strokeWidth={2} />
        </NavLink>
      ))}
      <NavLink
        to="/cart"
        aria-label="Cart"
        className={({ isActive }) =>
          cn('relative text-muted transition-colors hover:text-ink', isActive && 'text-ink')
        }
      >
        <ShoppingBag size={size} strokeWidth={2} />
        {itemCount > 0 && (
          <span className="absolute -right-2 -top-2 flex h-4 min-w-4 items-center justify-center rounded-full bg-volt px-1 text-[9px] font-extrabold text-volt-ink">
            {itemCount}
          </span>
        )}
      </NavLink>
    </>
  )
}

export function TopNav() {
  const navigate = useNavigate()
  const [searchParams] = useSearchParams()

  return (
    <>
      <div className="flex items-center justify-between border-b border-line bg-surface px-4 py-3 md:hidden">
        <NavLink to="/" aria-label="Home">
          <LogoMark fontSize={18} />
        </NavLink>
        <nav className="flex items-center gap-5">
          <IconLinks size={18} />
        </nav>
      </div>

      <header className="sticky top-0 z-10 hidden border-b border-line bg-surface md:block">
        <div className="mx-auto flex max-w-[1600px] items-center gap-6 px-8 py-4">
          <NavLink to="/" aria-label="Home">
            <LogoMark fontSize={22} />
          </NavLink>

          <div className="flex flex-1 items-center gap-2 rounded-pill bg-surface-2 px-4 py-2.5 text-muted">
            <Search size={16} strokeWidth={2.3} />
            <input
              defaultValue={searchParams.get('q') ?? ''}
              onChange={(e) => {
                const value = e.target.value
                navigate(value ? `/?q=${encodeURIComponent(value)}` : '/')
              }}
              placeholder="Search streetwear, sneakers…"
              className="w-full bg-transparent text-xs font-bold text-ink outline-none placeholder:font-bold placeholder:text-muted"
            />
          </div>

          <nav className="flex items-center gap-6">
            <IconLinks />
          </nav>
        </div>
      </header>
    </>
  )
}
