import type { Product } from '@/types/product'

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL

export async function getProducts(category?: string): Promise<Product[]> {
  const url = new URL('/api/products', API_BASE_URL)
  if (category) url.searchParams.set('category', category)

  const response = await fetch(url)
  if (!response.ok) throw new Error(`Failed to load products (${response.status})`)

  return response.json()
}
