import { Search, Zap } from 'lucide-react'
import { useEffect, useMemo, useState } from 'react'
import { useNavigate, useSearchParams } from 'react-router-dom'
import { Carousel } from '@/components/Carousel'
import { ProductCard } from '@/components/ProductCard'
import { SubcategoryBanner } from '@/components/SubcategoryBanner'
import { getProducts } from '@/lib/api'
import type { Product } from '@/types/product'

export default function HomePage() {
  const navigate = useNavigate()
  const [searchParams] = useSearchParams()
  const query = searchParams.get('q') ?? ''
  const selectedSubcategory = searchParams.get('sub')

  const [products, setProducts] = useState<Product[]>([])
  const [status, setStatus] = useState<'loading' | 'ready' | 'error'>('loading')

  useEffect(() => {
    getProducts()
      .then((data) => {
        setProducts(data)
        setStatus('ready')
      })
      .catch(() => setStatus('error'))
  }, [])

  const subcategories = useMemo(() => {
    const seen = new Map<string, string>()
    for (const p of products) {
      if (p.subcategorySlug && p.subcategoryName) seen.set(p.subcategorySlug, p.subcategoryName)
    }
    return Array.from(seen, ([slug, name]) => ({ slug, name }))
  }, [products])

  const filtered = useMemo(() => {
    return products.filter((p) => {
      if (selectedSubcategory && p.subcategorySlug !== selectedSubcategory) return false
      return true
    })
  }, [products, selectedSubcategory])

  const trending = useMemo(
    () => [...products].sort((a, b) => b.rating - a.rating).slice(0, 10),
    [products],
  )

  const searchResults = useMemo(() => {
    if (!query) return []
    const q = query.toLowerCase()
    return products.filter((p) => p.title.toLowerCase().includes(q))
  }, [products, query])

  if (query) {
    return (
      <div className="mx-auto max-w-[1600px] px-4 pt-5 sm:px-6 md:pt-8 lg:px-8">
        <div className="text-lg font-extrabold md:text-2xl">Results for "{query}"</div>
        <div className="mt-4 grid grid-cols-2 gap-4 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5">
          {searchResults.length === 0 && (
            <p className="col-span-full text-sm text-muted">No matches.</p>
          )}
          {searchResults.map((product) => (
            <ProductCard key={product.productId} product={product} />
          ))}
        </div>
      </div>
    )
  }

  return (
    <div>
      <div className="px-4 pt-5 md:hidden">
        <div className="flex items-center gap-2 rounded-pill bg-surface px-4 py-3 text-muted">
          <Search size={16} strokeWidth={2.3} />
          <input
            onChange={(e) => navigate(e.target.value ? `/?q=${encodeURIComponent(e.target.value)}` : '/')}
            placeholder="Search streetwear, sneakers…"
            className="w-full bg-transparent text-xs font-bold text-ink outline-none placeholder:font-bold placeholder:text-muted"
          />
        </div>
      </div>

      {subcategories.length > 0 && (
        <div className="mt-4 md:mt-0">
          <div className="mx-auto max-w-[1600px] px-4 sm:px-6 lg:px-8">
            <SubcategoryBanner subcategories={subcategories} />
          </div>
        </div>
      )}

      <div className="mx-auto max-w-[1600px] px-4 pb-10 pt-4 sm:px-6 lg:px-8">
        <div className="overflow-hidden rounded-card bg-ink p-5 text-bg md:p-10">
          <div className="flex items-center gap-1 text-[10px] font-extrabold tracking-[0.1em] text-volt">
            <Zap size={12} fill="currentColor" />
            VOLT DROP
          </div>
          <div className="mt-1 text-lg font-extrabold leading-tight md:text-3xl">
            30% off new
            <br />
            arrivals, today
          </div>
          <div className="mt-2 text-[11px] font-extrabold text-volt md:text-sm">Shop the drop →</div>
        </div>

        <div className="mt-8">
          <Carousel title="Plugg Trend Alerts">
            {trending.map((product) => (
              <div key={product.productId} className="w-52 shrink-0 sm:w-64 lg:w-72">
                <ProductCard product={product} />
              </div>
            ))}
          </Carousel>
        </div>

        <div className="mt-8">
          <Carousel title="Shop All">
            {status === 'loading' && <p className="text-sm text-muted">Loading products…</p>}
            {status === 'error' && (
              <p className="text-sm text-sale">Couldn't load products. Is the API running?</p>
            )}
            {status === 'ready' && filtered.length === 0 && (
              <p className="text-sm text-muted">No products in this category yet.</p>
            )}
            {filtered.map((product) => (
              <div key={product.productId} className="w-52 shrink-0 sm:w-64 lg:w-72">
                <ProductCard product={product} />
              </div>
            ))}
          </Carousel>
        </div>
      </div>
    </div>
  )
}
